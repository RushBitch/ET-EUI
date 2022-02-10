namespace ET
{
    public class CreateZoneScene:AEvent<EventType.CreateZoneScene>
    {
        protected override async ETTask Run(EventType.CreateZoneScene a)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), 1, SceneType.Zone, "Game", Game.Scene);
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<NetKcpComponent, int>(SessionStreamDispatcherType.SessionStreamDispatcherClientOuter);
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            zoneScene.AddComponent<UnitComponent>();
            await Game.EventSystem.PublishAsync(new EventType.MyAfterCreateZoneScene() {zoneScene = zoneScene});
            await ETTask.CompletedTask;
        }
    }
}