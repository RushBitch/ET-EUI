namespace ET
{
    public class LevelFlagComponentDestroySystem: DestroySystem<LevelFlagComponent>
    {
        public override void Destroy(LevelFlagComponent self)
        {
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }

    public static class LevelFlagComponentSystem
    {
        public static void Show(this LevelFlagComponent self)
        {
            self.gameObject.SetActive(true);
        }

        public static void Hide(this LevelFlagComponent self)
        {
            self.gameObject.SetActive(false);
        }
    }
}