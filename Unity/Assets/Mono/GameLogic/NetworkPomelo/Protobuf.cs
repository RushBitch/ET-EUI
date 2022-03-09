using System;
using LitJson;
using SimpleJson;

namespace ET
{
    public class Protobuf
    {
        private MsgDecoder decoder;
        private MsgEncoder encoder;

        public Protobuf(JsonObject encodeProtos, JsonObject decodeProtos)
        {
            this.encoder = new MsgEncoder(encodeProtos);
            this.decoder = new MsgDecoder(decodeProtos);
        }
        
        public Protobuf(JsonData encodeProtos, JsonData decodeProtos)
        {
            JsonObject encodeProtosSimpleJson = (JsonObject)SimpleJson.SimpleJson.DeserializeObject(JsonMapper.ToJson(encodeProtos)) ;
            JsonObject decodeProtosSimpleJson = (JsonObject) SimpleJson.SimpleJson.DeserializeObject(JsonMapper.ToJson(decodeProtos)) ;
            this.encoder = new MsgEncoder(encodeProtosSimpleJson);
            this.decoder = new MsgDecoder(decodeProtosSimpleJson);
        }

        public byte[] encode(string route, JsonData msg)
        {
            JsonObject simpleJson = (JsonObject) SimpleJson.SimpleJson.DeserializeObject(JsonMapper.ToJson(msg)) ;
            return encode(route, simpleJson);
        }

        public byte[] encode(string route, JsonObject msg)
        { 
            return encoder.encode(route, msg);
        }

        public JsonObject decode(string route, byte[] buffer)
        {
            return decoder.decode(route, buffer);
        }
    }
}