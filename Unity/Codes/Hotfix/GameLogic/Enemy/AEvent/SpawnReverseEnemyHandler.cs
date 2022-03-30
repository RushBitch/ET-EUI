using ET.EventType;

namespace ET
{
    public class SpawnReverseEnemyHandler: AEvent<SpawnReverseEnemy>
    {
        protected override async ETTask Run(SpawnReverseEnemy a)
        {
            if (a.unit.GetComponent<TowerDefenceIdComponent>() == null) return;
            long id = a.unit.GetComponent<TowerDefenceIdComponent>().ID;
            foreach (var towerDefence in ZoneSceneManagerComponent.Instance.Get(1).GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.Values)
            {
                if (towerDefence.Id == id)
                {
                    continue;
                }

                towerDefence.GetComponent<EnemySpawnComponent>()?.SpawnEnemy(a.unit.ConfigId);
            }

            await ETTask.CompletedTask;
        }
    }
}