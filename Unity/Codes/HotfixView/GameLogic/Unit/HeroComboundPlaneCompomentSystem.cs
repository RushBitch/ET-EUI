using UnityEngine;

namespace ET
{
    public class HeroComboundPlaneCompomentAwakeSystem: AwakeSystem<HeroComboundPlaneCompoment, Vector3>
    {
        public override void Awake(HeroComboundPlaneCompoment self, Vector3 position)
        {
            GameObject gameobject = (GameObject) ResourcesComponent.Instance.GetAsset("effect.unity3d", "CombundTip");

            self.gameObject = GameObject.Instantiate(gameobject);
            self.gameObject.SetActive(false);
            position.y += 0.05f;
            self.gameObject.transform.position = position;
            self.gameObject.transform.SetParent(GlobalComponent.Instance.Unit);
        }
    }

    public class HeroComboundPlaneCompomentDestroySystem: DestroySystem<HeroComboundPlaneCompoment>
    {
        public override void Destroy(HeroComboundPlaneCompoment self)
        {
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }

    public static class HeroComboundPlaneCompomentSystem
    {
        public static void Show(this HeroComboundPlaneCompoment self)
        {
            self.gameObject.SetActive(true);
        }

        public static void Hide(this HeroComboundPlaneCompoment self)
        {
            self.gameObject.SetActive(false);
        }
    }
}