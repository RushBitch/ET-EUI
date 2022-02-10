namespace ET
{
    public class TowerDefenceIdComponentAwakeSystem: AwakeSystem<TowerDefenceIdComponent, long>
    {
        public override void Awake(TowerDefenceIdComponent self, long id)
        {
            self.ID = id;
        }
    }
}