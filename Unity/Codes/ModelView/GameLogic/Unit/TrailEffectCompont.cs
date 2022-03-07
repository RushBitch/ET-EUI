using UnityEngine;

namespace ET
{
    public class TrailEffectCompont: Entity, IUpdate, IDestroy, IAwake
    {
        public GameObject followGameObject;
        public GameObject gameObject;
    }
}