using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class BattlefieldMapViewComponent:Entity, IAwake<Transform>, IDestroy
    {
        public Dictionary<int, GameObject> indexGameObjects;
        public GameObject gameObject;
    }
}