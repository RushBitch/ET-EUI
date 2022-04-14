using ET.EventType;
using UnityEngine;

namespace ET
{
    [NumericalWatcher(NumericalType.TowerDefenceHp)]
    public class TowerDefenceHpChangeHandler: INumericalWatcher
    {
        public void Run(long id, long value)
        {
            if (value < 0) return;
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out UIBaseWindow window);
            long myId = scene.GetComponent<PlayerComponent>().MyId;
            long towerdefenceID = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id).playerIds[0];
            if (window != null)
            {
                Transform transform;
                if (towerdefenceID == myId)
                {
                    transform = window.GetComponent<DlgTowerDefenceUIViewComponent>().ES_ButtomInfo.EG_MyHpRectTransform;
                    window.GetComponent<DlgTowerDefenceUI>().ShakeMyHp();
                    scene.GetComponent<TowerDefenceCompoment>().GetComponent<TowerDefenceCameraComponent>()?.Shake(1,0.25f);
                    SoundComponent.Instance.Play(Sound.撞击水晶掉血音效);
                }
                else
                {
                    transform = window.GetComponent<DlgTowerDefenceUIViewComponent>().ES_TopInfo.EG_EnemyMyHpRectTransform;
                    window.GetComponent<DlgTowerDefenceUI>().ShakeEmenyHp();
                }

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                for (int i = 0; i < value; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }

                if (value == 0)
                {
                    Game.EventSystem.Publish(new StopBattle() { TowerDecenceId = id });
                }
            }
        }
    }
}