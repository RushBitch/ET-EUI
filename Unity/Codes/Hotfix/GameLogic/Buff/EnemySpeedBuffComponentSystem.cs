using ET.EventType;

namespace ET
{
    public class EnemySpeedBuffComponentAwakeSystem: AwakeSystem<EnemySpeedBuffComponent, int, long>
    {
        public override void Awake(EnemySpeedBuffComponent self, int addition, long time)
        {
            self.Awake(addition, time);
        }
    }

    public class EnemySpeedBuffComponentUpdateSystem: UpdateSystem<EnemySpeedBuffComponent>
    {
        public override void Update(EnemySpeedBuffComponent self)
        {
            self.Update();
        }
    }

    public class EnemySpeedBuffComponentDestorySystem: DestroySystem<EnemySpeedBuffComponent>
    {
        public override void Destroy(EnemySpeedBuffComponent self)
        {
            self.Destroy();
        }
    }

    public static class EnemySpeedBuffComponentSystem
    {
        public static void Awake(this EnemySpeedBuffComponent self, int addition, long endTime)
        {
            self.addition = addition;
            self.endTime = endTime;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Speed);
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.SpeedBase, speed + self.addition);
            Game.EventSystem.Publish(new EnemySpeedBuffStart() { unit = (Unit) self.Parent });
        }

        public static void Update(this EnemySpeedBuffComponent self)
        {
            if (self.endTime <= TimeHelper.ServerNow())
            {
                self.Dispose();
            }
        }

        public static void Destroy(this EnemySpeedBuffComponent self)
        {
            if (self.Parent.IsDisposed) return;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Speed);
            self.Parent.GetComponent<NumericalComponent>()?.Set(NumericalType.SpeedBase, speed - self.addition);
            Game.EventSystem.Publish(new EnemySpeedBuffEnd() { unit = (Unit) self.Parent });
        }

        public static void Refresh(this EnemySpeedBuffComponent self, long endTime)
        {
            self.endTime = endTime;
        }
    }
}