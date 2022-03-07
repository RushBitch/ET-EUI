using System;
using System.IO;
using System.Text;
using SimpleJson;

namespace ET
{
    public enum MessageType
    {
        MSG_REQUEST = 0,
        MSG_NOTIFY = 1,
        MSG_RESPONSE = 2,
        MSG_PUSH = 3
    }

    public static class PomeloMessageHelper
    {
        public const int MSG_Route_Limit = 255;
        public const int MSG_Route_Mask = 0x01;
        public const int MSG_Type_Mask = 0x07;

        public static (long, MemoryStream) MessageToStream(object message, uint rpcId = 0)
        {
            if (message is HandShakeMessage_Request)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(SimpleJsonHelper.SerializeObject(message));
                MemoryStream stream = new MemoryStream(buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return ((long) PomeloPacketType.PKG_HANDSHAKE, stream);
            }

            if (message is HandShakeAckMessage)
            {
                byte[] buffer = new byte[0];
                MemoryStream stream = new MemoryStream(buffer.Length);
                stream.Write(buffer, 0, buffer.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return ((long) PomeloPacketType.PKG_HANDSHAKE_ACK, stream);
            }

            if (message is HeartBeatMessage)
            {
                MemoryStream stream = new MemoryStream(0);
                return ((long) PomeloPacketType.PKG_HEARTBEAT, stream);
            }

            if (message is KickMessage)
            {
            }

            if (message is IPomeloRequest)
            {
                // byte[] msg = EncodeRequest(message, rpcId);
                // MemoryStream stream = new MemoryStream(msg.Length);
                MemoryStream stream = EncodeRequest(message, rpcId);
                //stream.Write(msg, 0, msg.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return ((long) PomeloPacketType.PKG_DATA, stream);
            }

            if (message is IPomeloResponse)
            {
            }

            if (message is IPomeloMessage)
            {
            }

            return (0, null);
        }

        public static object DeserializeMessage(string message, Type type)
        {
            return SimpleJsonHelper.DeserializeObject(message, type);
        }

        public static MemoryStream EncodeRequest(object message, uint rpcId = 0)
        {
            //获取Route的byte
            byte[] routeBytes = PomeloRouteInfoComponent.Instance.GetMessageBytesByType(message.GetType());
            int routeLength = routeBytes.Length;
            if (routeLength > MSG_Route_Limit)
            {
                throw new Exception("Route的长度太长了!");
            }

            //构建Route的头
            byte[] head = new byte[routeLength + 6];
            int offset = 1;
            byte flag = 0;
            //写入回复ID
            if (rpcId > 0)
            {
                byte[] bytes = Encoder.encodeUInt32(rpcId);
                WriteBytes(bytes, offset, head);
                flag |= ((byte) MessageType.MSG_REQUEST) << 1;
                offset += bytes.Length;
            }
            else
            {
                flag |= ((byte) MessageType.MSG_NOTIFY) << 1;
            }
            //是否压缩路由头
            int compressCode = PomeloRouteInfoComponent.Instance.GetCompressCodeByType(message.GetType());
            if (compressCode != -1)
            {
                WriteShort(offset, (ushort) compressCode, head);
                flag |= MSG_Route_Mask;
                offset += 2;
            }
            else
            {
                //写入路由头的长度
                head[offset++] = (byte) routeLength;
                //写入路由头的内容
                WriteBytes(routeBytes, offset, head);
                offset += routeLength;
            }

            head[0] = flag;
            //构建路由的身体
            byte[] body = null;
            if (PomeloRouteInfoComponent.Instance.SendBodyNeedCompress(message.GetType()))
            {
                string route = PomeloRouteInfoComponent.Instance.GetRouteStrByType(message.GetType());
                JsonObject jsonObject = (JsonObject) SimpleJsonHelper.DeserializeObject(SimpleJsonHelper.SerializeObject(message));
                body = PomeloRouteInfoComponent.Instance.protobuf.encode(route, jsonObject);
            }
            else
            {
                body = Encoding.UTF8.GetBytes(SimpleJsonHelper.SerializeObject(message));
            }

            //写入路由身体
            MemoryStream stream = new MemoryStream(offset + body.Length);
            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(head, 0, offset);
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(body, 0, body.Length);
            stream.Seek(offset + body.Length, SeekOrigin.Begin);
            return stream;
        }

        public static void LogByte(byte[] bytes, string name = "send:")
        {
            string str = "";
            foreach (byte code in bytes)
            {
                str += code.ToString();
            }

            Log.Info(name + bytes.Length + " " + str.Length + "  " + str);
        }

        public static void WriteBytes(byte[] source, int offset, byte[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[offset + i] = source[i];
            }
        }

        public static void WriteShort(int offset, ushort value, byte[] bytes)
        {
            bytes[offset] = (byte) (value >> 8 & 0xff);
            bytes[offset + 1] = (byte) (value & 0xff);
        }
    }
}