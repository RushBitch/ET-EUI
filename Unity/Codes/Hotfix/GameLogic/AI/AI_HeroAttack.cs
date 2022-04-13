using System;
using ET.EventType;

namespace ET
{
    public class AI_HeroAttack: AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            UnitStateComponent unitStateComponent = aiComponent.Parent.GetComponent<UnitStateComponent>();
            if (unitStateComponent != null && unitStateComponent.unitState == UnitState.Attack)
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            if (unit == null)
            {
                return;
            }

            AttackComponent attackComponent = unit.GetComponent<AttackComponent>();
            if (attackComponent == null)
            {
                return;
            }

            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            while (true)
            {
                //预攻击
                bool ret = attackComponent.EnterReady();
                if (!ret)
                {
                    bool waitResult = await TimerComponent.Instance.WaitAsync(100, cancellationToken);
                    if (!waitResult)
                    {
                        break;
                    }

                    continue;
                }

                float speed = 1;
                speed = unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed) / 20f;
                //播放攻击动作
                Game.EventSystem.Publish(new HeroAttackBefore() { unit = unit });
                //攻击前摇
                speed = heroConfig.AttackBefore / speed + 1;
                //Log.Info("攻击前摇：" +speed.ToString());
                ret = await TimerComponent.Instance.WaitAsync((int) Math.Floor(speed), cancellationToken);
                if (!ret)
                {
                    break;
                }

                //攻击
                attackComponent.EnterAttack();

                if (unit.GetComponent<PreAttackComponent>() != null)
                {
                    unit.GetComponent<PreAttackComponent>().Dispose();
                }

                //攻击后摇
                speed = unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed) / 20f;
                speed = heroConfig.AttackAfter / speed + 1;
                //Log.Info("攻击后摇：" +speed.ToString());
                ret = await TimerComponent.Instance.WaitAsync((int) Math.Floor(speed), cancellationToken);
                if (!ret)
                {
                    break;
                }

                //播放Idle动作
                //if (heroConfig.CD != 0)   
                //{
                Game.EventSystem.Publish(new HeroAttackAfter() { unit = unit });
                //}
                speed = unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed) / 20f;
                speed = heroConfig.CD / speed + 1;
                //Log.Info("Idel：" +speed.ToString());
                //冷却
                ret = await TimerComponent.Instance.WaitAsync((int) Math.Floor(speed), cancellationToken);
                if (!ret)
                {
                    break;
                }

                UnitStateComponent unitStateComponent = aiComponent.Parent.GetComponent<UnitStateComponent>();
                if (unitStateComponent != null && unitStateComponent.unitState == UnitState.ReadySkill)
                {
                    unitStateComponent.unitState = UnitState.Skill;
                    break;
                }
            }

            if (unit.GetComponent<PreAttackComponent>() != null)
            {
                unit.GetComponent<PreAttackComponent>().EnablePreAttack();
                unit.GetComponent<PreAttackComponent>().Dispose();
            }
        }
    }
}