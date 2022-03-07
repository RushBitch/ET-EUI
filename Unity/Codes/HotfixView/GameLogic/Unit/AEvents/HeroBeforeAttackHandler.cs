using ET.EventType;

namespace ET
{
    public class HeroAttackBeforeHandler:AEvent<EventType.HeroAttackBefore>
    {
        protected async override ETTask Run(HeroAttackBefore args)
        {
            AnimationComponent animationComponent = args.unit.GetComponent<AnimationComponent>();
            if (animationComponent != null)
            {
                animationComponent.CrossFade(AnimType.攻击);
            }
            await ETTask.CompletedTask;
        }
    }
}