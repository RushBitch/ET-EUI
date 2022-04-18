using ET.EventType;

namespace ET
{
    public class AfterCompoundHeroHandler: AEvent<AfterCompoundHero>
    {
        protected override async ETTask Run(AfterCompoundHero args)
        {
            if ((UnitType) args.heroType == UnitType.BlackCat)
            {
                Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
                TowerDefenceCompoment towerDefenceCompoment = scene.GetComponent<TowerDefenceCompoment>();
                foreach (var defence in towerDefenceCompoment.playerIdTowerDefences.Values)
                {
                    if (defence.Id != args.towerDefenceId)
                    {
                        defence.GetComponent<EnemySpawnComponent>().SpawnEnemy(1002);
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}