using UnityEngine;

namespace ET
{
    public class HeroGreyComponentAwakeSystem: AwakeSystem<HeroGreyComponent, Renderer>
    {
        public override void Awake(HeroGreyComponent self, Renderer a)
        {
            self.renderer = a;
            self.material = a.materials[0];
            ResourcesComponent.Instance.LoadBundle("mat.unity3d");
            Material mat = (Material) ResourcesComponent.Instance.GetAsset("mat.unity3d", "CantCompound");
            self.greyMaterial = mat;
        }
    }

    public static class HeroGreyComponentSystem
    {
        public static void BecomeGrey(this HeroGreyComponent self)
        {
            self.renderer.material = self.greyMaterial;
        }

        public static void BecomeNormal(this HeroGreyComponent self)
        {
            self.renderer.material = self.material;
        }
    }
}