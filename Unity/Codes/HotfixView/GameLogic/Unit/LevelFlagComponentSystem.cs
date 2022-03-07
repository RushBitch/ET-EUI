namespace ET
{
    public class LevelFlagComponentDestroySystem: DestroySystem<LevelFlagComponent>
    {
        public override void Destroy(LevelFlagComponent self)
        {
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }
}