using System.Collections.Generic;

namespace ET
{

    public enum TowerDefenceMode
    {
        Solo,
        Pvp,
        Team,
        Null
    }
    
    public class TowerDefenceCompoment:Entity, IAwake
    {
        public Dictionary<long, TowerDefence> playerIdTowerDefences;
        public TowerDefenceMode towerDefenceMode;
    }
}