using ET.EventType;

namespace ET.AEvents
{
    public class AfterHeroAttackHandler: AEvent<HeroAttackAfter>
    {
        protected async override ETTask Run(HeroAttackAfter args)
        {
            AttackCountAIComponent attackCountAIComponent = args.unit.GetComponent<AttackCountAIComponent>();
            if (attackCountAIComponent == null)
            {
                return;
            }

            attackCountAIComponent.attackCount += 1;
            if (args.unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.AttackToSkillCount) <= attackCountAIComponent.attackCount)
            {
                if (args.unit.GetComponent<AttackComponent>().EnterSkillReady())
                {
                    args.unit.GetComponent<UnitStateComponent>().unitState = UnitState.Skill;
                }
                attackCountAIComponent.attackCount = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}