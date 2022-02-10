using ET.EventType;

namespace ET
{
    public class CreateTowerDefence_Pvp:AEvent<CreateTowerDefencePvp>
    {
        protected override async ETTask Run(CreateTowerDefencePvp args)
        {
            
            TowerDefenceCompoment towerDefenceCompoment = args.zoneScene.AddComponent<TowerDefenceCompoment>();
            towerDefenceCompoment.Start(TowerDefenceMode.Pvp);

            TowerDefence towerDefence = TowerDefenceFactory.Create(towerDefenceCompoment);
            BattlefieldEnemyPathConfig config = BattlefieldEnemyPathConfigCategory.Instance.Get(1002);
            towerDefence.GetComponent<EnemySpawnComponent>().AddPath(config);
            towerDefenceCompoment.Add(args.myId,towerDefence);
            towerDefence.playerIds.Add(args.myId);
            HeroSpawnComponent heroSpawnComponent = towerDefence.AddComponent<HeroSpawnComponent>();
            var list = BattlefieldMapConfigCategory.Instance.Get(1002).GetHeroSpawnIndexs();
            heroSpawnComponent.init(args.myId, list);

            towerDefence = TowerDefenceFactory.Create(towerDefenceCompoment);
            config = BattlefieldEnemyPathConfigCategory.Instance.Get(1002);
            towerDefence.GetComponent<EnemySpawnComponent>().AddPath(config);
            towerDefenceCompoment.Add(args.opponentId,towerDefence);
            towerDefence.playerIds.Add(args.opponentId);
            heroSpawnComponent = towerDefence.AddComponent<HeroSpawnComponent>();
            heroSpawnComponent.init(args.opponentId, list);

            await Game.EventSystem.PublishAsync(new AfterCreateTowerDefence() { towerDefenceCompoment = towerDefenceCompoment });
            await Game.EventSystem.PublishAsync(new EventType.FinishCreateTowerDefence() { towerDefenceCompoment = towerDefenceCompoment });
            await ETTask.CompletedTask;
        }
    }
}