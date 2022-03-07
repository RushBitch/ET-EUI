using ET.EventType;

namespace ET
{
    public class AfterCreateEnemyChangeUIHandler: AEvent<AfterCreateEnemy>
    {
        protected override async ETTask Run(AfterCreateEnemy args)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
                long playerId = towerDefence.playerIds[0];
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                if (playerId == playerComponent.MyId)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().AddMyEnemyCount();
                }
                else
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().AddEnemyEnemyCount();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}