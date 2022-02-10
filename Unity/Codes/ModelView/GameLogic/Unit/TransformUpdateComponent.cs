using UnityEngine;

namespace ET
{
    public class TransformUpdateComponent:Entity, IUpdate, IAwake
    {
        public Vector3 offset = Vector3.zero;
        public Vector3 scale = Vector3.one;
    }
}