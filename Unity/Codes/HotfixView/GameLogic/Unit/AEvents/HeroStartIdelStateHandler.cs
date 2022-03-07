using ET.EventType;

namespace ET
{
    public class HeroStartIdelStateHandler: AEvent<HeroStartIdelState>
    {
        protected override async ETTask Run(HeroStartIdelState args)
        {
            args.unit.GetComponent<AnimationComponent>()?.CrossFade(AnimType.闲置);
            await ETTask.CompletedTask;
        }
    }
}