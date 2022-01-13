using UnityEngine;

namespace ET
{
    public class EnemySpawnViewComponent: Entity, IAwake<Transform>, IAwake<GameObject>
    {
        public GameObject gameObject;
    }
}