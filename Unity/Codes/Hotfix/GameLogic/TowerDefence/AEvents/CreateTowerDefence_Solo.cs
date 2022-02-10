using ET.EventType;

namespace ET
{
    public class CreateTowerDefence_Solo: AEvent<CreateTowerDefenceSolo>
    {
        protected override async ETTask Run(CreateTowerDefenceSolo args)
        {
            TowerDefenceCompoment towerDefenceCompoment = args.zoneScene.AddComponent<TowerDefenceCompoment>();
            towerDefenceCompoment.Start(TowerDefenceMode.Solo);

            TowerDefence towerDefence = TowerDefenceFactory.Create(towerDefenceCompoment);
            BattlefieldEnemyPathConfig config = BattlefieldEnemyPathConfigCategory.Instance.Get(1001);
            towerDefence.GetComponent<EnemySpawnComponent>().AddPath(config);
            towerDefenceCompoment.Add(args.myId,towerDefence);
            
            HeroSpawnComponent heroSpawnComponent = towerDefence.AddComponent<HeroSpawnComponent>();
            var list = BattlefieldMapConfigCategory.Instance.Get(1001).GetHeroSpawnIndexs();
            heroSpawnComponent.init(args.myId, list);
            await Game.EventSystem.PublishAsync(new AfterCreateTowerDefence() { towerDefenceCompoment = towerDefenceCompoment });
            await Game.EventSystem.PublishAsync(new EventType.FinishCreateTowerDefence() { towerDefenceCompoment = towerDefenceCompoment });
            await ETTask.CompletedTask;
        }
    }
}