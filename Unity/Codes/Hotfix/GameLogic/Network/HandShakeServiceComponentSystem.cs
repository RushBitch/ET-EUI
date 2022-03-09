namespace ET
{
    public class HandShakeServiceAwakeSystem: AwakeSystem<HandShakeServiceComponent>
    {
        public override void Awake(HandShakeServiceComponent self)
        {
            self.Awake();
        }
    }

    public static class HandShakeServiceComponentSystem
    {
        public static void Awake(this HandShakeServiceComponent self)
        {
            self.tcs = ETTask<IMessage>.Create();
        }

        public static async ETTask StartServer(this HandShakeServiceComponent self)
        {
            HandShakeMessage_Request handShakeMessageRequest = new HandShakeMessage_Request();
            handShakeMessageRequest.sys.version = "0.3.0";
            handShakeMessageRequest.sys.type = "unity-socket";
            Session session = self.GetParent<Session>();
            session.Send(handShakeMessageRequest);
            HandShakeMessage_Response response = (HandShakeMessage_Response) await self.tcs;
            Log.Info("HandShake开启成功：" + response.code);
            PomeloRouteInfoComponent.Instance.InitProtobuf(response.str);
            session.Send(new HandShakeAckMessage());
            Log.Info("发送第三次握手");
            await TimerComponent.Instance.WaitAsync(1000);
        }
    }
}