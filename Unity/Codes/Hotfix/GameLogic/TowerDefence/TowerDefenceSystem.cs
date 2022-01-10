namespace ET
{
    [ObjectSystem]
    public class TowerDefenceSystem:AwakeSystem<TowerDefence,TowerDefenceType>
    {
        public override void Awake(TowerDefence self,TowerDefenceType towerDefenceType)
        {
            self.towerDefenceType = towerDefenceType;
        }
    }
}