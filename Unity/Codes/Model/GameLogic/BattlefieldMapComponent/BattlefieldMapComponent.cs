using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET
{
    public class BattlefieldMapComponent: Entity, IAwake<int[][]>, IDestroy
    {
        public int[][] battlefieldMap;
        public Dictionary<int, Vector3> IndexPositonDictionary;
    }
}