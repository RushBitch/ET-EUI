using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class MonsterMaterialConpoment: Entity, IAwake<GameObject>, IUpdate
    {
        public GameObject gameObject;
        public Dictionary<Renderer, Material> normalMatDic = null;
        public Material ForestMat;
    }
}