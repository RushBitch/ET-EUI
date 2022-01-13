using System.Collections.Generic;

namespace ET
{
    public class EnemySpawnComponent: Entity, IAwake
    {
        public Dictionary<long, EnemySpawnPoint> idSpawnPoint;
    }
}