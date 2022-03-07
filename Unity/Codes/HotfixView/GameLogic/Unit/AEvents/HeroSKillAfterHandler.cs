using ET.EventType;

namespace ET
{
    public class HeroSKillAfterHandler:AEvent<HeroSkillAfter>
    {
        protected async override ETTask Run(HeroSkillAfter args)
        {
            AnimationComponent animationComponent = args.unit.GetComponent<AnimationComponent>();
            if (animationComponent != null)
            {
                animationComponent.CrossFade(AnimType.闲置);
            }
            await ETTask.CompletedTask;
        }
    }
}