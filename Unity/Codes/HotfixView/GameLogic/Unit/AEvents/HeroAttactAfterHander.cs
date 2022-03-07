using ET.EventType;

namespace ET
{
    public class HeroAttackAfterHandler:AEvent<EventType.HeroAttackAfter>
    {
        protected async override ETTask Run(HeroAttackAfter args)
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