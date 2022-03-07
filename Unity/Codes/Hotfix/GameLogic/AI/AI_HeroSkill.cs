using ET.EventType;

namespace ET
{
    public class AI_HeroSkill: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            UnitStateComponent unitStateComponent = aiComponent.Parent.GetComponent<UnitStateComponent>();
            if (unitStateComponent != null && unitStateComponent.unitState == UnitState.Skill)
            {
                return 0;
            }
            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            AttackComponent attackComponent = aiComponent.Parent.GetComponent<AttackComponent>();
            UnitStateComponent unitStateComponent = aiComponent.Parent.GetComponent<UnitStateComponent>();
            NumericalComponent numericalComponent = aiComponent.Parent.GetComponent<NumericalComponent>();
            Game.EventSystem.Publish(new HeroSkillBefore() { unit = (Unit) aiComponent.Parent });
            bool ret = await TimerComponent.Instance.WaitAsync(numericalComponent.GetAsInt(NumericalType.SkillBeforeTime), cancellationToken);
            if (!ret)
            {
                return;
            }
            attackComponent.EnterSkill();
            ret = await TimerComponent.Instance.WaitAsync(numericalComponent.GetAsInt(NumericalType.SkillAfterTime), cancellationToken);
            if (!ret)
            {
                return;
            }
            Game.EventSystem.Publish(new HeroSkillAfter() { unit = (Unit) aiComponent.Parent });
            unitStateComponent.unitState = UnitState.Attack;
            await ETTask.CompletedTask;
        }
    }
}