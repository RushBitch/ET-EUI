using System.Collections.Generic;

namespace ET
{
    public static class TowerDefenceFactory
    {
        public static TowerDefence Create(TowerDefenceCompoment towerDefenceCompoment)
        {
            TowerDefence towerDefence = towerDefenceCompoment.AddChild<TowerDefence>();
            towerDefence.AddComponent<EnemySpawnComponent>();
            towerDefence.AddComponent<RecordMaxMoveDistanceComponent>();
            return towerDefence;
        }
    }
}