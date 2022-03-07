using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class MonsterMaterialConpomentUpdateSystem: AwakeSystem<MonsterMaterialConpoment,GameObject>
    {
        public override void Awake(MonsterMaterialConpoment self,GameObject gameObject)
        {
            self.gameObject = gameObject;
            self.normalMatDic = new Dictionary<Renderer, Material>();
            for (int i = 0; i < self.gameObject.transform.childCount; i++)
            {
                Renderer render = self.gameObject.transform.GetChild(i).GetComponent<Renderer>();
                if (render != null)
                {
                    self.normalMatDic.Add(render, render.material);
                }
            }

            ResourcesComponent.Instance.LoadBundle("Mat.unity3d");
            if (self.GetParent<Unit>().Config.Type == 0)
            {
                self.ForestMat = (Material) ResourcesComponent.Instance.GetAsset("Mat.unity3d", "jiebing");
            }
            else
            {
                self.ForestMat = (Material) ResourcesComponent.Instance.GetAsset("Mat.unity3d", "jiebing 1");
            }
        }
    }

    public static class MonsterMaterialConpomentSystem
    {
        public static void BecomeForest(this MonsterMaterialConpoment self)
        {
            for (int i = 0; i < self.gameObject.transform.childCount; i++)
            {
                Renderer render = self.gameObject.transform.GetChild(i).GetComponent<Renderer>();
                if (render != null)
                {
                    render.material = self.ForestMat;
                }
            }
        }

        public static void BecomeNormal(this MonsterMaterialConpoment self)
        {
            for (int i = 0; i < self.gameObject.transform.childCount; i++)
            {
                Renderer render = self.gameObject.transform.GetChild(i).GetComponent<Renderer>();
                if (render != null)
                {
                    self.normalMatDic.TryGetValue(render, out Material mat);
                    render.material = mat;
                }
            }
        }
    }
}