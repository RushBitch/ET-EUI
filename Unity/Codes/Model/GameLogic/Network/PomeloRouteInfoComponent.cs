using System;
using System.Collections.Generic;
using LitJson;
using SimpleJson;

namespace ET
{
    public class PomeloRouteInfoComponent: Entity, IAwake
    {
        public static PomeloRouteInfoComponent Instance;
        public Dictionary<Type, byte[]> typeBytes = new Dictionary<Type, byte[]>();
        public Dictionary<int, Type> codeMessageType = new Dictionary<int, Type>();
        public Dictionary<int, Type> codeRequestTypes = new Dictionary<int, Type>();
        public Dictionary<int, Type> codeResponseTypes = new Dictionary<int, Type>();
        public Dictionary<Type, int> typeCode = new Dictionary<Type, int>();
        public Dictionary<int, string> codeStr = new Dictionary<int, string>();
        public Dictionary<int, int> routeCodeCompressCode = new Dictionary<int, int>();
        public Dictionary<int, int> compressCodeRouteCode = new Dictionary<int, int>();

        public JsonData encodeProtos;
        public JsonData decodeProtos;
        
        public Protobuf protobuf;
    }
}