namespace ET
{
    [ObjectSystem]
    public class BattlefieldPlayerAwakeSystem:AwakeSystem<BattlefieldPlayer,long>
    {
        public override void Awake(BattlefieldPlayer self,long id)
        {
            self.playerId = id;
        }
    }
}