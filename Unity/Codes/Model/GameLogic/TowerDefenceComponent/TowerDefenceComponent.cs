using System.Collections.Generic;

namespace ET
{
    public class TowerDefenceComponent: Entity, IAwake<TowerDefenceType>, IDestroy
    {
        public TowerDefenceType towerDefenceType;
        public long[] battlefieldIds;
    }
}