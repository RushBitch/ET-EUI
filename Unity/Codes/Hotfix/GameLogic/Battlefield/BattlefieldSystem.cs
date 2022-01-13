namespace ET
{
    [ObjectSystem]
    public class BattlefieldAwakeSystem: AwakeSystem<Battlefield>
    {
        public override void Awake(Battlefield self)
        {
            self.BattlefieldPlayers.Clear();
        }
    }
    
    [ObjectSystem]
    public class BattlefieldDestroySystem: DestroySystem<Battlefield>
    {
        public override void Destroy(Battlefield self)
        {
            self.BattlefieldPlayers.Clear();
        }
    }

    public static class BattlefieldSystem
    {
        public static void AllotBattlefield(this Battlefield self)
        {
            
        }

        public static void AddBattlefieldPlayer(this Battlefield self, long id)
        {
            BattlefieldPlayer battlefieldPlayer = self.AddChildWithId<BattlefieldPlayer>(id);
            self.BattlefieldPlayers.Add(battlefieldPlayer);
        }

        public static void SetUp(this Battlefield self)
        {
            
        }
    }
}