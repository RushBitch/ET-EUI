namespace ET
{
    [PomeloMessage(RouteString.gate_gateHandler_queryEnter)]
    public partial class gate_gateHandler_queryEnter_Request: Object, IPomeloRequest
    {
        public string uid;
    }

    [PomeloMessage(RouteString.gate_gateHandler_queryEnter)]
    public partial class gate_gateHandler_queryEnter_Response: Object, IPomeloResponse
    {
        public int code;
        public string host;
        public string port;
    }

    [PomeloMessage(RouteString.connector_entryHandler_enter)]
    public partial class connector_entryHandler_enter_Request: Object, IPomeloRequest
    {
        public string username;
        public string rid;
    }

    [PomeloMessage(RouteString.connector_entryHandler_enter)]
    public partial class connector_entryHandler_enter_Response: Object, IPomeloResponse
    {
        public string[] users;
    }

    [PomeloMessage(RouteString.chat_chatHandler_send)]
    public partial class chat_chatHandler_send_Request: Object, IPomeloRequest
    {
        public string rid;
        public string content;
        public string from;
        public string target;
    }

    [PomeloMessage(RouteString.chat_chatHandler_send)]
    public partial class chat_chatHandler_send_Response: Object, IPomeloResponse
    {
    }
    
    [PomeloMessage(RouteString.onChat)]
    public partial class onChat_Message: Object, IPomeloMessage
    {
        public string msg;
        public string from;
        public string target;
    }
}