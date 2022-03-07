using UnityEngine;

namespace ET
{
    public class PositionUpdateComponent:Entity,IAwake, IUpdate
    {
        public Vector3 offset = Vector3.zero;
        public Vector3 scale = Vector3.one;
    }
}