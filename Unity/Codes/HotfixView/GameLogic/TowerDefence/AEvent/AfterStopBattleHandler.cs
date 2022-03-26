using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterStopBattleHandler: AEvent<AfterStopBattle>
    {
        protected override async ETTask Run(AfterStopBattle a)
        {
            ResourcesComponent.Instance.LoadBundle("effect.unity3d");
            GameObject gameObject = (GameObject) ResourcesComponent.Instance.GetAsset("effect.unity3d", "Boom");
            GameObject boom = UnityEngine.Object.Instantiate(gameObject);
            boom.transform.SetParent(GlobalComponent.Instance.Unit);
            boom.transform.localPosition = new Vector3();
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            scene.GetComponent<TowerDefenceCompoment>().GetComponent<TowerDefenceCameraComponent>().Shake(2, 0.5f);
            long myId = scene.GetComponent<PlayerComponent>().MyId;
            long towerdefenceID = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(a.TowerDecenceId).playerIds[0];

            if (towerdefenceID == myId)
            {
                boom.transform.position = new Vector3(2.501f, 0, -5.782f);
            }
            else
            {
                boom.transform.position = new Vector3(2.501f, 0, 5.782f);
            }

            await TimerComponent.Instance.WaitAsync(5000);
            UnityEngine.Object.Destroy(boom);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().OnBackToMainButton();
            }

            await ETTask.CompletedTask;
        }
    }
}