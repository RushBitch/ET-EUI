namespace ET
{
    public class FinishCreateTowerDefence:AEvent<EventType.FinishCreateTowerDefence>
    {
        protected override async ETTask Run(EventType.FinishCreateTowerDefence args)
        {
            foreach (var towerDefence in args.towerDefenceCompoment.playerIdTowerDefences.Values)
            {
                towerDefence.GetComponent<EnemySpawnComponent>()?.StartSpawnEnemy();
            }
            await ETTask.CompletedTask;
        }
    }
}