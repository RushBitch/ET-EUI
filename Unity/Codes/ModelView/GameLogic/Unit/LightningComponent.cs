using UnityEngine;

namespace ET
{
    public class LightningComponent:Entity,IAwake<GameObject>,IDestroy, IUpdate
    {
        public GameObject gameObject;
        public GameObject startGameObject;
        public GameObject lightGameObejct;
        public Vector3 offset = Vector3.zero;
        public Vector3 scale = Vector3.one;
        public Vector3 startPoint;
        public Vector3 endPoint;
        public ParticleSystem particleSystem;
        public Material material;
    }
}