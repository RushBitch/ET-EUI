namespace ET
{
    [PomeloMessageHandler]
    public class OnChatHandler: AMHandler<onChat_Message>
    {
        protected override async ETTask Run(Session session, onChat_Message message)
        {
            Log.Info($"收到了消息：{message.msg}");
            await ETTask.CompletedTask;
        }
    }
}