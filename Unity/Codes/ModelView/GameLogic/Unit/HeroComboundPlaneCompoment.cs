using UnityEngine;

namespace ET
{
    public class HeroComboundPlaneCompoment: Entity, IAwake, IDestroy, IAwake<Vector3>
    {
        public GameObject gameObject;
    }
}