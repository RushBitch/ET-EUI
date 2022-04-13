using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class RebbitSkillComponentAwakeSystem: AwakeSystem<RebbitSkillComponent>
    {
        public override void Awake(RebbitSkillComponent self)
        {
            self.Awake();
        }
    }

    public class RebbitSkillComponentUpdateSystem: UpdateSystem<RebbitSkillComponent>
    {
        public override void Update(RebbitSkillComponent self)
        {
            self.Update();
        }
    }

    public class RebbitSkillComponentDestorySystem: DestroySystem<RebbitSkillComponent>
    {
        public override void Destroy(RebbitSkillComponent self)
        {
            self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
        }
    }

    public static class RebbitSkillComponentSystem
    {
        public static void Awake(this RebbitSkillComponent self)
        {
            self.startAttack = false;
        }

        public static void Update(this RebbitSkillComponent self)
        {
            if (!self.startAttack)
                return;
            // if (self.enemy == null)
            // {
            //     self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            //     return;
            // }
            // if (self.enemy.IsDisposed)
            // {
            //     self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            //     return;
            // }

            float delta = MyTimeHelper.GetDeltaTime();
            Vector3 dir = self.enemyPosition - self.GetParent<Unit>().Position;
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            self.SetPosition(self.GetParent<Unit>().Position + dir.normalized * delta * self.speed);
            // Vector3 pos;
            List<Unit> units = new List<Unit>();
            // pos = (self.hero.GetComponent<AttackComponent>().attackEnemy != null && self.hero.GetComponent<AttackComponent>().attackEnemy.IsDisposed)
            //         ? self.hero.GetComponent<AttackComponent>().skillPosition
            //         : self.hero.GetComponent<AttackComponent>().attackEnemy.Position;
            if (dir.magnitude < 0.2)
            {
                foreach (var entity in unitComponent.Children.Values)
                {
                    var unit = (Unit) entity;
                    if (unit.GetComponent<MoveWithListComponent>() != null)
                    {
                        if (unit.GetComponent<TowerDefenceIdComponent>().ID == self.towerDefenceId)
                        {
                            if (Vector3.Distance(unit.Position, self.enemyPosition) <= self.attackRange)
                            {
                                if (!unit.GetComponent<LifeComponent>().preDead)
                                {
                                    units.Add(unit);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < units.Count; i++)
                {
                    units[i].GetComponent<LifeComponent>().PreAttacked(self.damage);
                    bool isDead = units[i].GetComponent<LifeComponent>().Attacked(self.damage);
                    if (isDead)
                    {
                        Game.EventSystem.Publish(new EnemyKilledByHero() { id = self.towerDefenceId });
                    }
                }

                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            }
        }

        public static void StartAttack(this RebbitSkillComponent self)
        {
            self.startAttack = true;
        }

        public static void SetPosition(this RebbitSkillComponent self, Vector3 position)
        {
            self.GetParent<Unit>().Position = position;
        }
    }
}