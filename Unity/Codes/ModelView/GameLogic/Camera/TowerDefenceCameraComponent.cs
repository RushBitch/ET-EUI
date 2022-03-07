using UnityEngine;

namespace ET
{
    public class TowerDefenceCameraComponent:Entity,IAwake<GameObject>
    {
        public GameObject gameObject;
        public Vector3 farPos;
        public Quaternion farQuaternion;
        public Vector3 nearPos;
        public Quaternion nearQuaternion;
    }
}