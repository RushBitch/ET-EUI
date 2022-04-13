using ET.EventType;

namespace ET
{
    public class AfterDestroyRebbiteSkillComponentDestorySystem: DestroySystem<AfterDestroyRebbiteSkillComponent>
    {
        public override void Destroy(AfterDestroyRebbiteSkillComponent self)
        {
            Game.EventSystem.Publish(new PlayerEffect()
            {
                effectId = 1313, effectTime = 1000, pos = self.Parent.GetComponent<GameObjectComponent>().GameObject.transform.position
            });
        }
    }
}