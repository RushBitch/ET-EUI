using System;
using ET.EventType;

namespace ET
{
    namespace EventType
    {
        public struct AfterCountDown
        {
            public int count;
        }
    }

    [Timer(TimerType.CountDownTimer)]
    public class CountDownTimer: ATimer<CountDownComponent>
    {
        public override void Run(CountDownComponent self)
        {
            try
            {
                self.count -= 1;
                CountDownComponent.additionCount += 1;
                Game.EventSystem.Publish(new AfterCountDown() { count = self.count });
                if (self.count <= 0)
                {
                    TimerComponent.Instance?.Remove(ref self.countDownTimer);
                }
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    public class CountDownComponentDestorySystem: DestroySystem<CountDownComponent>
    {
        public override void Destroy(CountDownComponent self)
        {
            TimerComponent.Instance?.Remove(ref self.countDownTimer);
        }
    }

    public static class CountDownComponentSystem
    {
        public static void StartCountDown(this CountDownComponent self, int count)
        {
            self.count = count;
            //self.additionCount = 0;
            //TimerComponent.Instance?.Remove(ref self.countDownTimer);
            self.countDownTimer = TimerComponent.Instance.NewRepeatedTimer(1000, TimerType.CountDownTimer, self);
        }
    }
}