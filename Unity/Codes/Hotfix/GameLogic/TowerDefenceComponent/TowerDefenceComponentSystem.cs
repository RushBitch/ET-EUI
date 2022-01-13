namespace ET
{
    [ObjectSystem]
    public class TowerDefenceComponentAwakeSystem:AwakeSystem<TowerDefenceComponent,TowerDefenceType>
    {
        public override void Awake(TowerDefenceComponent self,TowerDefenceType towerDefenceType)
        {
            self.towerDefenceType = towerDefenceType;
        }
    }
    
    [ObjectSystem]
    public class TowerDefenceComponentDestroySystem:DestroySystem<TowerDefenceComponent>
    {
        public override void Destroy(TowerDefenceComponent self)
        {
            
        }
    }
}