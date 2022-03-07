namespace ET
{
    public class HeartBeatMessage: IMessage
    {
    }

    public class HeartBeatComponent: Entity, IAwake, IDestroy
    {
        public HeartBeatMessage heartBeatMessage = new HeartBeatMessage();
        public ETTask tcs;
        public long Ping; //延迟值
    }
}