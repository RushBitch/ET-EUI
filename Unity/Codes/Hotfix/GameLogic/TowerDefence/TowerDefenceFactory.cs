namespace ET
{
    public static class TowerDefenceFactory
    {
        public static TowerDefence CreateSolo(Scene zoneScene)
        {
            TowerDefence towerDefence = zoneScene.AddChild<TowerDefence,TowerDefenceType>(TowerDefenceType.Solo);
            Battlefield battlefield = towerDefence.AddChild<Battlefield>();
            //拿到地图数据
            //需要地图数据
            battlefield.AddComponent<BattlefieldMapComponent>();
            //拿到玩家数据
            battlefield.AddBattlefieldPlayer(IdGenerater.Instance.GenerateId());
            battlefield.SetUp();
            return towerDefence;
        }
        
        public static TowerDefence CreatePvp(Scene zoneScene)
        {
            TowerDefence towerDefence = zoneScene.AddChild<TowerDefence,TowerDefenceType>(TowerDefenceType.Pvp);
            return towerDefence;
            
        }
        
        public static TowerDefence CreateTeam(Scene zoneScene)
        {
            TowerDefence towerDefence = zoneScene.AddChild<TowerDefence,TowerDefenceType>(TowerDefenceType.Team);
            return towerDefence;
        }
    }
}