using DG.Tweening;

namespace ET
{
    public class MyAfterCreateZoneScene: AEvent<EventType.MyAfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.MyAfterCreateZoneScene args)
        {
            Scene zoneScene = args.zoneScene;
            zoneScene.AddComponent<LanguageComponent, LangueageType>(LangueageType.中文);
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MenuUI);
            long id = IdGenerater.Instance.GenerateId();
            zoneScene.GetComponent<PlayerComponent>().MyId = id;
            zoneScene.AddComponent<MainCameraComponent>();
            DOTween.SetTweensCapacity(3000, 200);
            await ETTask.CompletedTask;
        }
    }
}