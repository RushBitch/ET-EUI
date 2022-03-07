using System;
using System.IO;
using System.Text;
using SimpleJson;

namespace ET
{
    [SessionStreamDispatcher(SessionStreamDispatcherType.SessionStreamDispatcherPomelo)]
    public class SessionStreamDispatcherPolome: ISessionStreamDispatcher
    {
        public const int MSG_Route_Limit = 255;
        public const int MSG_Route_Mask = 0x01;
        public const int MSG_Type_Mask = 0x07;

        public void Dispatch(Session session, MemoryStream stream)
        {
            //PomeloMessageHelper.LogByte(stream.GetBuffer(), "收到消息");
            //获取包的类型
            PomeloPacketType packageType = (PomeloPacketType) stream.GetBuffer()[0];
            //按照包的不同类型解析分发
            switch (packageType)
            {
                case PomeloPacketType.PKG_HANDSHAKE:
                    DispatchHandShake(session, stream);
                    break;
                case PomeloPacketType.PKG_DATA:
                    DispatchData(session, stream);
                    break;
                case PomeloPacketType.PKG_HEARTBEAT:
                    DispatchHeartBeat(session, stream);
                    break;
                case PomeloPacketType.PKG_KICK:
                    DispatchKick(session);
                    break;
                default:
                    break;
            }
        }

        private void DispatchHandShake(Session session, MemoryStream stream)
        {
            string bytesStr = stream.GetBuffer().ToStr(1, stream.GetBuffer().Length - 1);
            object msg = PomeloMessageHelper.DeserializeMessage(bytesStr, typeof (HandShakeMessage_Response));
            session.GetComponent<HandShakeServiceComponent>().tcs.SetResult((HandShakeMessage_Response) msg);
        }

        private void DispatchData(Session session, MemoryStream stream)
        {
            int offset = 2;
            byte[] buffer = stream.GetBuffer();
            byte flag = buffer[1];
            MessageType type = (MessageType) ((flag >> 1) & MSG_Type_Mask);
            int routeCode;
            byte[] body;
            switch (type)
            {
                case MessageType.MSG_RESPONSE:
                {
                    uint id = Decoder.decodeUInt32(offset, buffer, out int length);
                    offset += length;
                    body = new byte[buffer.Length - offset];
                    for (int i = 0; i < body.Length; i++)
                    {
                        body[i] = buffer[i + offset];
                    }

                    Type messageType = session.GetRequestType((int) id);
                    routeCode = PomeloRouteInfoComponent.Instance.GetRouteCodeByTybe(messageType);
                    Type responseType = PomeloRouteInfoComponent.Instance.GetResponseTypeByCode(routeCode);
                    object message = null;
                    if (PomeloRouteInfoComponent.Instance.RecieveBodyNeedCompress(messageType))
                    {
                        JsonObject jsonObject =
                                PomeloRouteInfoComponent.Instance.protobuf.decode(PomeloRouteInfoComponent.Instance.GetRouteStrByType(responseType),
                                    body);
                        message = SimpleJsonHelper.DeserializeObject(jsonObject.ToString(), responseType);
                    }
                    else
                    {
                        message = PomeloMessageHelper.DeserializeMessage(Encoding.UTF8.GetString(body), responseType);
                    }

                    if (message is IPomeloResponse pomeloResponse)
                    {
                        session.OnRead(routeCode, pomeloResponse, (int) id);
                    }

                    break;
                }
                case MessageType.MSG_PUSH:
                {
                    if ((flag & 0x01) == 1)
                    {
                        ushort routeId = ReadShort(offset, buffer);
                        routeCode = PomeloRouteInfoComponent.Instance.GetRouteCodeByCompressCode(routeId);
                        offset += 2;
                    }
                    else
                    {
                        byte length = buffer[offset];
                        offset += 1;
                        routeCode = Util.BytesToInt(buffer, offset, length);
                        offset += length;
                    }
                   
                    Type messageType = PomeloRouteInfoComponent.Instance.GetMessageTypeByCode(routeCode);
                    if (messageType != null)
                    {
                        body = new byte[buffer.Length - offset];
                        for (int i = 0; i < body.Length; i++)
                        {
                            body[i] = buffer[i + offset];
                        }

                        object message = null;
                        if (PomeloRouteInfoComponent.Instance.RecieveBodyNeedCompress(messageType))
                        {
                            JsonObject jsonObject =
                                    PomeloRouteInfoComponent.Instance.protobuf.decode(
                                        PomeloRouteInfoComponent.Instance.GetRouteStrByType(messageType),
                                        body);
                            message = SimpleJsonHelper.DeserializeObject(jsonObject.ToString(), messageType);
                        }
                        else
                        {
                            message = PomeloMessageHelper.DeserializeMessage(Encoding.UTF8.GetString(body), messageType);
                        }

                        PomeloMessageDispatcherComponent.Instance.Handle(session, routeCode, message);
                    }

                    break;
                }
                default:
                    return;
            }
        }

        private static void DispatchHeartBeat(Session session, MemoryStream stream)
        {
            HeartBeatComponent heartBeatComponent = session.GetComponent<HeartBeatComponent>();
            if (heartBeatComponent == null)
            {
                Log.Info("没有心跳组件");
                return;
            }

            heartBeatComponent.tcs.SetResult();
        }

        private static void DispatchKick(Session session)
        {
            Log.Info($"id：{session.Id}被服务器踢出");
            session.Dispose();
        }
        
        private static ushort ReadShort(int offset, byte[] bytes)
        {
            ushort result = 0;

            result += (ushort) (bytes[offset] << 8);
            result += (ushort) (bytes[offset + 1]);

            return result;
        }
    }
}