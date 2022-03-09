using System;
using System.Collections.Generic;
using System.Text;
using LitJson;
using SimpleJson;

namespace ET
{
    public class PomeloRouteInfoComponentAwakeSystem: AwakeSystem<PomeloRouteInfoComponent>
    {
        public override void Awake(PomeloRouteInfoComponent self)
        {
            self.Awake();
        }
    }

    public static class PomeloRouteInfoComponentSystem
    {
        public static void Awake(this PomeloRouteInfoComponent self)
        {
            self.typeBytes.Clear();
            self.codeRequestTypes.Clear();
            self.codeResponseTypes.Clear();
            self.typeCode.Clear();
            self.codeMessageType.Clear();
            self.codeStr.Clear();
            PomeloRouteInfoComponent.Instance = self;

            HashSet<Type> types = Game.EventSystem.GetTypes(typeof (PomeloMessageAttribute));
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof (PomeloMessageAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                PomeloMessageAttribute messageAttribute = attrs[0] as PomeloMessageAttribute;
                if (messageAttribute == null)
                {
                    continue;
                }

                self.typeBytes.Add(type, messageAttribute.GetRouteByte());

                self.typeCode.Add(type, messageAttribute.GetRouteCode());
                if (typeof (IPomeloMessage).IsAssignableFrom(type))
                {
                    self.codeMessageType.Add(messageAttribute.GetRouteCode(), type);
                }

                if (typeof (IPomeloResponse).IsAssignableFrom(type))
                {
                    self.codeResponseTypes.Add(messageAttribute.GetRouteCode(), type);
                }

                if (typeof (IPomeloRequest).IsAssignableFrom(type))
                {
                    self.codeRequestTypes.Add(messageAttribute.GetRouteCode(), type);
                }

                if (!self.codeStr.ContainsKey(messageAttribute.GetRouteCode()))
                {
                    self.codeStr.Add(messageAttribute.GetRouteCode(), messageAttribute.GetRouteStr());
                }
            }
        }

        public static byte[] GetMessageBytesByType(this PomeloRouteInfoComponent self, Type type)
        {
            byte[] bytes = null;
            self.typeBytes.TryGetValue(type, out bytes);
            if (bytes == null)
            {
                Log.Error($"无法找到类型{type}对于的Routebutys");
            }

            return bytes;
        }

        public static Type GetRequestTypeByCode(this PomeloRouteInfoComponent self, int code)
        {
            Type type = null;
            self.codeRequestTypes.TryGetValue(code, out type);
            if (type == null)
            {
                Log.Error($"无法找到code:{type}对于的RequestType");
            }

            return type;
        }

        public static Type GetResponseTypeByCode(this PomeloRouteInfoComponent self, int code)
        {
            Type type = null;
            self.codeResponseTypes.TryGetValue(code, out type);
            if (type == null)
            {
                Log.Error($"无法找到code:{type}对于的ResponseType");
            }

            return type;
        }

        public static Type GetMessageTypeByCode(this PomeloRouteInfoComponent self, int code)
        {
            Type type = null;
            self.codeMessageType.TryGetValue(code, out type);
            if (type == null)
            {
                Log.Error($"无法找到code:{code}对于的MessageType");
            }

            return type;
        }

        public static int GetRouteCodeByTybe(this PomeloRouteInfoComponent self, Type type)
        {
            int code = -1;
            self.typeCode.TryGetValue(type, out code);
            if (code == -1)
            {
                Log.Error($"无法找到type:{type}对于的RouteCode");
            }

            return code;
        }

        public static string GetRouteStrByType(this PomeloRouteInfoComponent self, Type type)
        {
            int code = -1;
            self.typeCode.TryGetValue(type, out code);
            if (code == -1)
            {
                Log.Error($"无法找到type:{type}对于的RouteCode");
            }

            string routrStr = null;
            self.codeStr.TryGetValue(code, out routrStr);
            if (routrStr == null)
            {
                Log.Error($"无法找到type:{type}对于的RouteStr");
            }

            return routrStr;
        }

        public static void InitProtobuf(this PomeloRouteInfoComponent self, string config)
        {
            JsonData jsonData = JsonMapper.ToObject(config);
            JsonData jsonObject = jsonData["sys"];
            Log.Info("初始化protobuf");
            JsonData dict = new JsonData();
            JsonData protos = new JsonData();
            JsonData serverProtos = new JsonData();
            JsonData clientProtos = new JsonData();
            if (jsonObject["dict"] != null)
            {
                dict = jsonObject["dict"];
            }

            ICollection<string> keys = dict.Keys;

            foreach (string key in keys)
            {
                ushort value = (ushort) dict[key];
                byte[] bytes = Encoding.UTF8.GetBytes(key);
                int routeCode = Util.BytesToInt(bytes, 0, bytes.Length);
                if (!self.routeCodeCompressCode.ContainsKey(routeCode))
                {
                    self.routeCodeCompressCode.Add(routeCode, value);
                }

                if (!self.compressCodeRouteCode.ContainsKey(value))
                {
                    self.compressCodeRouteCode.Add(value, routeCode);
                }
            }

            if (jsonObject["protos"] != null)
            {
                protos = jsonObject["protos"];
                serverProtos = protos["server"];
                clientProtos = protos["client"];
            }

            self.protobuf = new Protobuf(clientProtos, serverProtos);
            self.encodeProtos = clientProtos;
            self.decodeProtos = serverProtos;
        }

        public static bool SendBodyNeedCompress(this PomeloRouteInfoComponent self, Type type)
        {
            if (self.typeCode.TryGetValue(type, out int code))
            {
                self.codeStr.TryGetValue(code, out string str);
                if (str != null && self.encodeProtos[str] != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool RecieveBodyNeedCompress(this PomeloRouteInfoComponent self, Type type)
        {
            if (self.typeCode.TryGetValue(type, out int code))
            {
                self.codeStr.TryGetValue(code, out string str);
                if (str != null && self.decodeProtos[str] != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetCompressCodeByType(this PomeloRouteInfoComponent self, Type type)
        {
            self.typeCode.TryGetValue(type, out int key);
            int code = -1;
            self.routeCodeCompressCode.TryGetValue(key, out code);
            if (code == -1)
            {
                Log.Error($"无法找到CompressCode:{key}对应的RouteCode");
            }

            return code;
        }

        public static int GetRouteCodeByCompressCode(this PomeloRouteInfoComponent self, int key)
        {
            int code = -1;
            self.compressCodeRouteCode.TryGetValue(key, out code);
            if (code == -1)
            {
                Log.Error($"无法找到RouteCode:{key}对应的CompressCode");
            }

            return code;
        }
    }
}