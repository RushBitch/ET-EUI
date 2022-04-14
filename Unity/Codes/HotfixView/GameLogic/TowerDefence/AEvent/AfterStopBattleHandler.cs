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
            scene.GetComponent<TowerDefenceCompoment>().GetComponent<TowerDefenceCameraComponent>().Shake(2, 0.25f);
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
            
            scene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_TowerDefenceUI);
            BgmComponent.Instance.Stop();
            await TimerComponent.Instance.WaitAsync(1000);
            SoundComponent.Instance.Play(Sound.水晶爆炸完整);
            await TimerComponent.Instance.WaitAsync(2000);
            if (towerdefenceID == myId)
            {
                GameObject shuijin = GameObject.Find("cj_2/shuijingtai");
                shuijin.transform.localScale = Vector3.zero;
                shuijin.transform.GetChild(0).GetChild(0).localScale = Vector3.zero;
            }
            else
            {
                GameObject shuijin = GameObject.Find("cj_2/shuijingtai (1)");
                shuijin.transform.localScale = Vector3.zero;
                shuijin.transform.GetChild(0).GetChild(0).localScale = Vector3.zero;
            }

            await TimerComponent.Instance.WaitAsync(3500);
            UnityEngine.Object.Destroy(boom);

            scene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SettleUI);
            UIBaseWindow window;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_SettleUI, out window);
            if (window != null)
            {
                if (towerdefenceID == myId)
                {
                    window.GetComponent<DlgSettleUI>().ShowLose();
                }
                else
                {
                    window.GetComponent<DlgSettleUI>().ShowWin();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}