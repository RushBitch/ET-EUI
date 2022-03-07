using ET.EventType;

namespace ET
{
    public class AI_HeroIdle: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            UnitStateComponent unitStateComponent = aiComponent.Parent.GetComponent<UnitStateComponent>();
            if (unitStateComponent != null && unitStateComponent.unitState == UnitState.Idle)
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Game.EventSystem.Publish(new HeroStartIdelState() { unit = (Unit) aiComponent.Parent });
            await ETTask.CompletedTask;
        }
    }
}