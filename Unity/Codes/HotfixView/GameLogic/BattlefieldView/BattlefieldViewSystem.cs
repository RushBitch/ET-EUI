using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class BattlefieldViewAwakeSystem: AwakeSystem<BattlefieldView, GameObject>
    {
        public override void Awake(BattlefieldView self, GameObject gameObject)
        {
            self.Awake(gameObject);
        }
    }

    [ObjectSystem]
    public class BattlefieldViewDestroySystem: DestroySystem<BattlefieldView>
    {
        public override void Destroy(BattlefieldView self)
        {
            GameObject.Destroy(self.BattleRoot);
        }
    }

    public static class BattlefieldViewSystem
    {
        public static void Awake(this BattlefieldView self, GameObject gameObject)
        {
            GameObject root = new GameObject();
            root.name = "Battlefield";
            root.transform.SetParent(gameObject.transform);
            root.transform.position = Vector3.zero;
            self.BattleRoot = root;
        }
    }
}