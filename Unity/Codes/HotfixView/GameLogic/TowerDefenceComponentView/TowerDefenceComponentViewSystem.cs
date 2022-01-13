using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class TowerDefenceViewAwakeSystem: AwakeSystem<TowerDefenceComponentView>
    {
        public override void Awake(TowerDefenceComponentView self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class TowerDefenceViewDestorySystem: DestroySystem<TowerDefenceComponentView>
    {
        public override void Destroy(TowerDefenceComponentView self)
        {
            self.Destroy();
        }
    }

    public static class TowerDefenceComponentViewSystem
    {
        public static void Awake(this TowerDefenceComponentView self)
        {
            GameObject root = new GameObject();
            root.name = "TowerDefenceRoot";
            root.transform.SetParent(GlobalComponent.Instance.Global);
            root.transform.position = Vector3.zero;
            self.towerDefenceRoot = root;
        }

        public static void Destroy(this TowerDefenceComponentView self)
        {
            GameObject.Destroy(self.towerDefenceRoot); 
        }
    }
}