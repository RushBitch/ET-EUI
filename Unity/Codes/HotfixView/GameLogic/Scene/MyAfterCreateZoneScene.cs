namespace ET
{
    public class MyAfterCreateZoneScene:AEvent<EventType.MyAfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.MyAfterCreateZoneScene args)
        {
            Scene zoneScene = args.zoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MenuUI);
            
            

            long id = IdGenerater.Instance.GenerateId();
            zoneScene.GetComponent<PlayerComponent>().MyId = id;
            zoneScene.AddComponent<MainCameraComponent>();
            await ETTask.CompletedTask;
        }
    }
}