using UnityEngine;

namespace ET
{
    public class LightningComponentAwakeSystem: AwakeSystem<LightningComponent, GameObject>
    {
        public override void Awake(LightningComponent self, GameObject a)
        {
            self.gameObject = a;
            self.startGameObject = self.gameObject.transform.GetChild(0).gameObject;
            self.lightGameObejct = self.gameObject.transform.GetChild(1).gameObject;
            self.startPoint = Vector3.zero;
            self.endPoint = Vector3.zero;
            //self.particleSystem = self.lightGameObejct.GetComponent<ParticleSystem>();
        }
    }

    public class LightningComponentDestroySystem: DestroySystem<LightningComponent>
    {
        public override void Destroy(LightningComponent self)
        {
            self.DelayDestroy().Coroutine();
        }
    }

    public class LightningComponentUpdateSystem: UpdateSystem<LightningComponent>
    {
        public override void Update(LightningComponent self)
        {
            self.endPoint = Vector3.Scale(self.GetParent<Unit>().Position, self.scale) + self.offset;
            self.gameObject.transform.position = self.startPoint + (self.endPoint - self.startPoint).normalized * 0.5f + new Vector3(0, 0.3f, 0);
            self.gameObject.transform.LookAt(self.endPoint);
            self.lightGameObejct.transform.localScale = new Vector3(Vector3.Distance(self.startPoint, self.endPoint) * 0.55f, 1f, 1f);
        }
    }

    public static class LightningComponentSystem
    {
        public static void UpdateStartPos(this LightningComponent self)
        {
            self.gameObject.transform.position = self.startPoint;
        }

        public static async ETTask DelayDestroy(this LightningComponent self)
        {
            await TimerComponent.Instance.WaitAsync(200);
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }
}