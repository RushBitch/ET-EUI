using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AttackComponentDestroySystem: DestroySystem<AttackComponent>
    {
        public override void Destroy(AttackComponent self)
        {
            self.Parent.GetComponent<PreAttackComponent>()?.EnablePreAttack();
        }
    }

    public static class AttackComponentSystem
    {
        public static bool EnterReady(this AttackComponent self)
        {
            //获取敌人并判断敌人血量是否能够死亡，如果可以则让其置为预死亡，同时移除它的最远距离
            long id = self.Parent.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = self.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);

            Unit enemy = towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit;
            if (enemy != null && !enemy.IsDisposed)
            {
                //Log.Info($"有可以预攻击的对象：{enemy.Id}");
                self.attackEnemy = enemy;
                Unit unit = (Unit) self.Parent;
                if (unit.Config.Type == (int) UnitType.Fox)
                {
                    self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HeroDamageBase, RandomHelper.RandomNumber(1, 70));
                }

                int damage = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
                enemy.GetComponent<LifeComponent>().PreAttacked(damage);
                PreAttackComponent preAttackComponent = self.Parent.AddComponent<PreAttackComponent>();
                preAttackComponent.enemys.Add(enemy);
                preAttackComponent.damage = damage;
                if (unit.Config.Type == (int) UnitType.Cheetah)
                {
                    CheetahExtraAttackComponent cheetahExtraAttackComponent = self.Parent.GetComponent<CheetahExtraAttackComponent>();
                    cheetahExtraAttackComponent.PreAttack(enemy, damage);
                    foreach (var theEmeny in cheetahExtraAttackComponent.enemys)
                    {
                        preAttackComponent.enemys.Add(theEmeny);
                    }
                }

                return true;
            }
            else
            {
                self.attackEnemy = null;
                return false;
            }
        }

        public static void EnterAttack(this AttackComponent self)
        {
            if (self.attackEnemy != null)
            {
                Game.EventSystem.Publish(new HeroExecuteAttack() { unit = (Unit) self.Parent });
            }
        }

        public static bool EnterSkillReady(this AttackComponent self)
        {
            Game.EventSystem.Publish(new HeroEnterSkillReady() { unit = (Unit) self.Parent });
            return self.canExeuteSkill;
        }

        public static void EnterSkill(this AttackComponent self)
        {
            Game.EventSystem.Publish(new HeroExecuteSkill() { unit = (Unit) self.Parent });
        }

        public static void StopAttack(this AttackComponent self)
        {
            self.stop = true;
        }

        public static void PuseAttack(this AttackComponent self)
        {
            self.stop = true;
        }

        public static void ResumeAttack(this AttackComponent self)
        {
            self.stop = false;
        }
    }
}