using ET.EventType;

namespace ET
{
    public class EnemyBreakDefenceHandler: AEvent<EnemyBreakDefence>
    {
        protected async override ETTask Run(EnemyBreakDefence args)
        {
            long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            TowerDefence towerDefence = scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
            NumericalComponent numericalComponent = towerDefence.GetComponent<NumericalComponent>();
            numericalComponent.Set(NumericalType.TowerDefenceHpBase, numericalComponent.GetAsInt(NumericalType.TowerDefenceHp) - 1);
            if ((UnitType) args.unit.Config.Type == UnitType.Boss)
            {
                if (scene.GetComponent<TowerDefenceCompoment>().GetComponent<CountDownComponent>().count <= 0)
                {
                    scene.GetComponent<TowerDefenceCompoment>().GetComponent<CountDownComponent>().StartCountDown(120);
                    foreach (var VARIABLE in scene.GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.Values)
                    {
                        VARIABLE.GetComponent<EnemySpawnComponent>().StartSpawnEnemy();
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}