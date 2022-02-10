using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateTowerDefecceHandler:AEvent<AfterCreateTowerDefence>
    {
        protected override async ETTask Run(AfterCreateTowerDefence args)
        {
            args.towerDefenceCompoment.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_MenuUI);
            await ResourcesComponent.Instance.LoadBundleAsync("Map.unity3d");
            UnityEngine.Object bundle = ResourcesComponent.Instance.GetAsset("Map.unity3d", args.towerDefenceCompoment.towerDefenceMode.ToString());
            GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(bundle,GlobalComponent.Instance.Global);
            args.towerDefenceCompoment.AddComponent<GameObjectComponent>().GameObject = gameObject;
            args.towerDefenceCompoment.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_TowerDefenceUI);
            await ETTask.CompletedTask;
        }
    }
}