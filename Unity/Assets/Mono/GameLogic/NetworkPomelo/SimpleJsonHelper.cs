using System;
using SimpleJson;

namespace ET
{
    public static class SimpleJsonHelper
    {
        public static string SerializeObject(object o)
        {
            return JsonHelper.ToJson(o);
            //return SimpleJson.SimpleJson.SerializeObject(o);
        }
        
        public static object DeserializeObject(string json,Type type)
        {
            return JsonHelper.FromJson(type, json);
            //return SimpleJson.SimpleJson.DeserializeObject(json,type);
        }
    }
}