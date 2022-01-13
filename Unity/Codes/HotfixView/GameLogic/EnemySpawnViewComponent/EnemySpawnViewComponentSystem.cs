using UnityEngine;

namespace ET
{
    public class EnemySpawnViewComponentAwakeSystem:AwakeSystem<EnemySpawnViewComponent,Transform>
    {
        public override void Awake(EnemySpawnViewComponent self, Transform transform)
        {
            self.Awake(transform);
        }
    }
    
    public static class EnemySpawnViewComponentSystem
    {
        public static void Awake(this EnemySpawnViewComponent self,Transform parent)
        {
            GameObject root = new GameObject();
            root.name = self.ToString();
            root.transform.parent = parent;
            root.transform.localPosition = Vector3.zero;
            self.gameObject = root;
            EnemySpawnComponent enemySpawnComponent = (EnemySpawnComponent) self.Parent;
            foreach (var point in enemySpawnComponent.idSpawnPoint.Values)
            {
                GameObject gameObjectBundle = (GameObject) (ResourcesComponent.Instance.GetAsset("MapGrid.Unity3d", "SpawnPoint"));
                GameObject gameObject = UnityEngine.Object.Instantiate(gameObjectBundle,root.transform);
                point.AddComponent<EnemySpawnPointView,GameObject>(gameObject);
            }
        }
    }
}