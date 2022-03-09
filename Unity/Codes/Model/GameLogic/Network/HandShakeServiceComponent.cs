namespace ET
{
    public class PomeloSystemInfo
    {
        public string version;
        public string type;
    }

    public class PomeloUsernfo
    {
    }

    public class HandShakeMessage_Request: IMessage
    {
        public PomeloSystemInfo sys = new PomeloSystemInfo();
        public PomeloUsernfo user = new PomeloUsernfo();
    }
    
    public class HandShakeAckMessage: IMessage
    {
    }

    public class HandShakeMessage_Response: IMessage
    {
        public int code;
        public string str;
    }

    public class HandShakeServiceComponent: Entity, IAwake
    {
        public ETTask<IMessage> tcs;
    }
}