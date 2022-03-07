using System;

namespace ET
{
    [ObjectSystem]
    public class HeartBeatComponentAwakesSystem: AwakeSystem<HeartBeatComponent>
    {
        public override void Awake(HeartBeatComponent self)
        {
            PingAsync(self).Coroutine();
        }

        private static async ETTask PingAsync(HeartBeatComponent self)
        {
            Session session = self.GetParent<Session>();
            long instanceId = self.InstanceId;
            
            while (true)
            {
                if (self.InstanceId != instanceId)
                {
                    return;
                }

                long time1 = TimeHelper.ClientNow();
                try
                {
                    self.tcs = ETTask.Create(true);
                    session.Send(self.heartBeatMessage);
                    await self.tcs;
                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }

                    long time2 = TimeHelper.ClientNow();
                    self.Ping = time2 - time1;
                    await TimerComponent.Instance.WaitAsync(2000);
                }
                catch (RpcException e)
                {
                    // session断开导致ping rpc报错，记录一下即可，不需要打成error
                    Log.Info($"ping error: {self.Id} {e.Error}");
                    return;
                }
                catch (Exception e)
                {
                    Log.Error($"ping error: \n{e}");
                }
            }
        }
    }

    [ObjectSystem]
    public class HeartBeatComponentDestroySystem: DestroySystem<HeartBeatComponent>
    {
        public override void Destroy(HeartBeatComponent self)
        {
            self.Ping = default;
        }
    }
    
}