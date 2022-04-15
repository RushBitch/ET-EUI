using ET.EventType;

namespace ET
{
    public class RemoveEnemyHandler1: AEvent<AfterEnemyDead>
    {
        protected override async ETTask Run(AfterEnemyDead a)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                long id = a.unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
                long playerId = towerDefence.playerIds[0];
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                if (playerId == playerComponent.MyId)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().RemoveMyEnemyCount();
                }
                else
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().RemoveEnemyEnemyCount();
                }
            }

            if ((UnitType) a.unit.Config.Type == UnitType.Boss)
            {
                if (scene.GetComponent<TowerDefenceCompoment>().GetComponent<CountDownComponent>().count <= 0)
                {
                    //scene.GetComponent<TowerDefenceCompoment>().GetComponent<CountDownComponent>().StartCountDown(120);
                    // foreach (var VARIABLE in scene.GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.Values)
                    // {
                    //     VARIABLE.GetComponent<EnemySpawnComponent>().StartSpawnEnemy();
                    // }
                }
            }

            await ETTask.CompletedTask;
        }
    }

    public class RemoveEnemyHandler2: AEvent<EnemyBreakDefence>
    {
        protected override async ETTask Run(EnemyBreakDefence a)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            UIBaseWindow dlgTowerDefenceUI;
            scene.GetComponent<UIComponent>().VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out dlgTowerDefenceUI);
            if (dlgTowerDefenceUI != null)
            {
                long id = a.unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
                long playerId = towerDefence.playerIds[0];
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                if (playerId == playerComponent.MyId)
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().RemoveMyEnemyCount();
                }
                else
                {
                    dlgTowerDefenceUI.GetComponent<DlgTowerDefenceUI>().RemoveEnemyEnemyCount();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}