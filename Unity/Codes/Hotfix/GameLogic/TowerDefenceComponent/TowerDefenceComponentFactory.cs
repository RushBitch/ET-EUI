namespace ET
{
    namespace EventType
    {
        public struct AfterCreateTowerDefence
        {
            public TowerDefenceComponent TowerDefence;
        }
    }

    public static class TowerDefenceComponentFactory
    {
        public static TowerDefenceComponent CreateSolo(Scene zoneScene)
        {
            //创建塔防对局
            TowerDefenceComponent towerDefence = zoneScene.AddChild<TowerDefenceComponent, TowerDefenceType>(TowerDefenceType.Solo);
            towerDefence.battlefieldIds = new long[1];
            //添加战场
            Battlefield battlefield = towerDefence.AddChild<Battlefield>();
            towerDefence.battlefieldIds[0] = battlefield.Id;
            //拿到地图数据
            BattlefieldMapConfig battlefieldMapConfig = BattlefieldMapConfigCategory.Instance.Get(1001);
            //添加地图组件
            battlefield.AddComponent<BattlefieldMapComponent, int[][]>(battlefieldMapConfig.battlefieldMap);
            //添加玩家数据
            battlefield.AddBattlefieldPlayer(IdGenerater.Instance.GenerateId());
            //配置玩家位置等
            battlefield.SetUp();
            //更新显示层
            Game.EventSystem.PublishAsync(new EventType.AfterCreateTowerDefence() { TowerDefence = towerDefence });
            return towerDefence;
        }

        public static TowerDefenceComponent CreatePvp(Scene zoneScene)
        {
            //创建塔防对局
            TowerDefenceComponent towerDefence = zoneScene.AddChild<TowerDefenceComponent, TowerDefenceType>(TowerDefenceType.Pvp);
            towerDefence.battlefieldIds = new long[2];
            long[] playerIds = { IdGenerater.Instance.GenerateId(), IdGenerater.Instance.GenerateId() };

            for (int i = 0; i < playerIds.Length; i++)
            {
                //添加战场
                Battlefield battlefield = towerDefence.AddChild<Battlefield>();
                towerDefence.battlefieldIds[i] = battlefield.Id;
                //拿到地图数据
                BattlefieldMapConfig battlefieldMapConfig = BattlefieldMapConfigCategory.Instance.Get(1002);
                //添加地图组件
                battlefield.AddComponent<BattlefieldMapComponent, int[][]>(battlefieldMapConfig.battlefieldMap);
                //添加玩家数据
                battlefield.AddBattlefieldPlayer(playerIds[i]);
                //配置玩家位置等
                battlefield.SetUp();
            }

            //更新显示层
            Game.EventSystem.PublishAsync(new EventType.AfterCreateTowerDefence() { TowerDefence = towerDefence });
            return towerDefence;
        }

        public static TowerDefenceComponent CreateTeam(Scene zoneScene)
        {
            //创建塔防对局
            TowerDefenceComponent towerDefence = zoneScene.AddChild<TowerDefenceComponent, TowerDefenceType>(TowerDefenceType.Team);
            towerDefence.battlefieldIds = new long[1];
            //添加战场
            Battlefield battlefield = towerDefence.AddChild<Battlefield>();
            towerDefence.battlefieldIds[0] = battlefield.Id;
            //拿到地图数据
            BattlefieldMapConfig battlefieldMapConfig = BattlefieldMapConfigCategory.Instance.Get(1003);
            //添加地图组件
            battlefield.AddComponent<BattlefieldMapComponent, int[][]>(battlefieldMapConfig.battlefieldMap);
            //添加玩家数据
            battlefield.AddBattlefieldPlayer(IdGenerater.Instance.GenerateId());
            battlefield.AddBattlefieldPlayer(IdGenerater.Instance.GenerateId());
            //配置玩家位置等
            battlefield.SetUp();
            //更新显示层
            Game.EventSystem.PublishAsync(new EventType.AfterCreateTowerDefence() { TowerDefence = towerDefence });
            return towerDefence;
        }
    }
}