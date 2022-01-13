namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MenuUI);

            await ETTask.CompletedTask;
        }
    }
}