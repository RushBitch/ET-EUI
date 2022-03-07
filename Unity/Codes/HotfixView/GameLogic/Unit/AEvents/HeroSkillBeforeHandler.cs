using ET.EventType;

namespace ET
{
    public class HeroSkillBeforeHandler:AEvent<HeroSkillBefore>
    {
        protected async override ETTask Run(HeroSkillBefore args)
        {
            AnimationComponent animationComponent = args.unit.GetComponent<AnimationComponent>();
            if (animationComponent != null)
            {
                animationComponent.CrossFade(AnimType.技能);
            }
            await ETTask.CompletedTask;
        }
    }
}