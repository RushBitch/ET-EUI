using ET.EventType;

namespace ET
{
    public class CreateTowerDefence_Team: AEvent<CreateTowerDefenceTeam>
    {
        protected override async ETTask Run(CreateTowerDefenceTeam args)
        {
            TowerDefenceCompoment towerDefenceCompoment = args.zoneScene.AddComponent<TowerDefenceCompoment>();
            towerDefenceCompoment.Start(TowerDefenceMode.Team);

            BattlefieldEnemyPathConfig config;
            
            config = BattlefieldEnemyPathConfigCategory.Instance.Get(args.myIndex == 0? 1003 : 1004);
            TowerDefence towerDefence = TowerDefenceFactory.Create(towerDefenceCompoment);
            towerDefence.GetComponent<EnemySpawnComponent>().AddPath(config);
            towerDefenceCompoment.Add(args.myId, towerDefence);
            HeroSpawnComponent heroSpawnComponent = towerDefence.AddComponent<HeroSpawnComponent>();
            var list = BattlefieldMapConfigCategory.Instance.Get(1003).GetHeroSpawnIndexsInPvp((int)args.myIndex);
            heroSpawnComponent.init(args.myId, list);
            
            towerDefence = TowerDefenceFactory.Create(towerDefenceCompoment);
            config = BattlefieldEnemyPathConfigCategory.Instance.Get(args.opponentIndex == 0? 1003 : 1004);
            towerDefence.GetComponent<EnemySpawnComponent>().AddPath(config);
            towerDefenceCompoment.Add(args.opponentId, towerDefence);
            list = BattlefieldMapConfigCategory.Instance.Get(1003).GetHeroSpawnIndexsInPvp((int)args.opponentIndex);
            heroSpawnComponent.init(args.opponentId, list);

            await Game.EventSystem.PublishAsync(new AfterCreateTowerDefence() { towerDefenceCompoment = towerDefenceCompoment });
            await ETTask.CompletedTask;
        }
    }
}