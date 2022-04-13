namespace ET
{
    [Timer(TimerType.DeltaTimeAITimer)]
    public class DeltaTimeAITimer: ATimer<DeltaTimeAIComponent>
    {
        public override void Run(DeltaTimeAIComponent t)
        {
            if (t.Parent.GetComponent<UnitStateComponent>().unitState == UnitState.Idle) return;
            t.Parent.GetComponent<UnitStateComponent>().unitState = UnitState.ReadySkill;
        }
    }

    public class DeltaTimeAIComponentAwakeSystem: AwakeSystem<DeltaTimeAIComponent>
    {
        public override void Awake(DeltaTimeAIComponent self)
        {
            int skillShowTime = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.DeltaTimeToSkill);
            self.timer = TimerComponent.Instance.NewRepeatedTimer(skillShowTime, TimerType.DeltaTimeAITimer, self);
        }
    }

    public class DeltaTimeAIComponentDestorySystem: DestroySystem<DeltaTimeAIComponent>
    {
        public override void Destroy(DeltaTimeAIComponent self)
        {
            TimerComponent.Instance?.Remove(ref self.timer);
        }
    }

    public static class DeltaTimeAIComponentSystem
    {
    }
}