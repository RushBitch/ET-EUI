namespace ET
{
    public class TrailEffectComponentUpdateSystem: UpdateSystem<TrailEffectCompont>
    {
        public override void Update(TrailEffectCompont self)
        {
            self.Update();
        }
    }

    public class TrailEffectComponentDestroySystem: DestroySystem<TrailEffectCompont>
    {
        public override async void Destroy(TrailEffectCompont self)
        {
            await TimerComponent.Instance.WaitAsync(300);
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }

    public static class TrailEffectComponentSystem
    {
        public static void Update(this TrailEffectCompont self)
        {
            if (self.followGameObject != null && self.gameObject != null)
            {
                self.gameObject.transform.position = self.followGameObject.transform.position;
            }
        }
    }
}