using UnityEngine;

namespace ET
{
    public class HeroGreyComponent:Entity,IAwake<Renderer>
    {
        public Renderer renderer;
        public Material material;
        public Material greyMaterial;
    }
}