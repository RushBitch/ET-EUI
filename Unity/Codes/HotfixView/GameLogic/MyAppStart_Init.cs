using ET.EventType;

namespace ET
{
    public class MyAppStart_Init: AEvent<EventType.MyAppStart>
    {
        protected override async ETTask Run(EventType.MyAppStart args)
        {
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            // 加载配置
            Game.Scene.AddComponent<ResourcesComponent>();
            await ResourcesComponent.Instance.LoadBundleAsync("config.unity3d");
            Game.Scene.AddComponent<ConfigComponent>();
            ConfigComponent.Instance.Load();
            ResourcesComponent.Instance.UnloadBundle("config.unity3d");

            // Game.Scene.AddComponent<OpcodeTypeComponent>();
            // Game.Scene.AddComponent<MessageDispatcherComponent>();

            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();

            Game.Scene.AddComponent<GlobalComponent>();
            Game.Scene.AddComponent<NumericalWatcherComponent>();
            Game.Scene.AddComponent<AIDispatcherComponent>();
            Game.Scene.AddComponent<PomeloRouteInfoComponent>();
            Game.Scene.AddComponent<PomeloMessageDispatcherComponent>();
            await ResourcesComponent.Instance.LoadBundleAsync("unit.unity3d");
            await Game.EventSystem.PublishAsync(new EventType.CreateZoneScene());
            await Game.EventSystem.PublishAsync(new EventType.MyAppStartInitFinish());
        }
    }
}