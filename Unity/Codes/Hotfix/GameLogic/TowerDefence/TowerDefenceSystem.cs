using System.Collections.Generic;

namespace ET
{
    public class TowerDefenceAwakeSystem:AwakeSystem<TowerDefence>
    {
        public override void Awake(TowerDefence self)
        {
            self.playerIds = new List<long>();
        }
    }
    
    public static class TowerDefenceSystem
    {
        
    }
}