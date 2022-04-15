using ET.EventType;

namespace ET
{
    public class StopBattleHandler: AEvent<StopBattle>
    {
        protected override async ETTask Run(StopBattle a)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            TowerDefenceCompoment towerDefenceCompoment = scene.GetComponent<TowerDefenceCompoment>();
            //TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(a.TowerDecenceId);
            foreach (var towerDefence in towerDefenceCompoment.playerIdTowerDefences.Values)
            {
                towerDefence.GetComponent<EnemySpawnComponent>().StopSpawnEnemy();
                towerDefence.GetComponent<AutoSpawnHeroComponent>()?.Dispose();
            }

            //让其他怪物不走动
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            foreach (var unit in unitComponent.Children.Values)
            {
                if (unit.GetComponent<MoveWithListComponent>() != null)
                {
                    unit.GetComponent<MoveWithListComponent>().Dispose();
                }

                if (unit.GetComponent<AIComponent>() != null)
                {
                    unit.GetComponent<UnitStateComponent>().unitState = UnitState.Idle;
                }
            }

            towerDefenceCompoment.GetComponent<CountDownComponent>()?.Dispose();

            Game.EventSystem.Publish(new AfterStopBattle() { TowerDecenceId = a.TowerDecenceId });
            await ETTask.CompletedTask;
        }
    }
}