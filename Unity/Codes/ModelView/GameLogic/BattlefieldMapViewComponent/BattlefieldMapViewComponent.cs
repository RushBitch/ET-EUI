using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BattlefieldMapViewComponent:Entity, IAwake, IAwake<Transform>, IDestroy
    {
        public Dictionary<int, GameObject> indexGameObjects;
        public Transform mapGridParent;
    }
}