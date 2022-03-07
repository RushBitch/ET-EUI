using System;

namespace ET
{
    public static class SimpleJsonHelper
    {
        public static string SerializeObject(object o)
        {
            return SimpleJson.SimpleJson.SerializeObject(o);
        }

        public static object DeserializeObject(string json)
        {
            return SimpleJson.SimpleJson.DeserializeObject(json);
        }

        public static object DeserializeObject(string json,Type type)
        {
            return SimpleJson.SimpleJson.DeserializeObject(json,type);
        }
    }
}