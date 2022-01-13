using System.Collections.Generic;

namespace ET
{
    public class Battlefield: Entity, IAwake, IDestroy
    {
        public List<BattlefieldPlayer> BattlefieldPlayers = new List<BattlefieldPlayer>();
    }
}