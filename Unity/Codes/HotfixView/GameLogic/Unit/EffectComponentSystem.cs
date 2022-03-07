namespace ET
{
    [Timer(TimerType.EffectShowTimer)]
    public class EffectShowTimer: ATimer<EffectComponent>
    {
        public override void Run(EffectComponent self)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            unitComponent.Remove(self.Id);
        }
    }
    
    public static class EffectComponentSystem
    {
        public static void Start(this EffectComponent self)
        {
            TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + self.showTime, TimerType.EffectShowTimer, self);
        } 
    }
}