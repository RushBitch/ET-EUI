using System.Collections.Generic;

namespace ET
{
    public class EnemySpawnComponent:Entity, IAwake, IDestroy
    {
        public List<BattlefieldEnemyPathConfig> pathConfigs;
        public long spwanTimer;
        public int spawnCount;
    }
}