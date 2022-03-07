using System;
using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class StoneSkillComponentDestorySystem: DestroySystem<StoneSkillComponent>
    {
        public override void Destroy(StoneSkillComponent self)
        {
            self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
        }
    }

    public static class StoneSkillComponentSystem
    {
        public static async void StartAttack(this StoneSkillComponent self)
        {
            self.Attack();
            await TimerComponent.Instance.WaitAsync(self.attackTime);
            self.Dispose();
        }

        public static void Attack(this StoneSkillComponent self)
        {
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            Unit hero = unitComponent.Get(self.heroId);
            Vector3 pos;
            pos = (hero.GetComponent<AttackComponent>().attackEnemy != null && hero.GetComponent<AttackComponent>().attackEnemy.IsDisposed)
                    ? hero.GetComponent<AttackComponent>().skillPosition
                    : hero.GetComponent<AttackComponent>().attackEnemy.Position;
            long heroDefenceId = hero.GetComponent<TowerDefenceIdComponent>().ID;
            List<Unit> units = new List<Unit>();
            foreach (var entity in unitComponent.Children.Values)
            {
                var unit = (Unit) entity;
                if (unit.GetComponent<MoveWithListComponent>() != null)
                {
                    if (unit.GetComponent<TowerDefenceIdComponent>().ID == heroDefenceId)
                    {
                        if (Vector3.Distance(unit.Position, pos) <= self.attackRange)
                        {
                            units.Add(unit);
                        }
                    }
                }
            }

            for (int i = 0; i < units.Count; i++)
            {
                bool isDead = units[i].GetComponent<LifeComponent>().Attacked(self.damage);
                if (isDead)
                {
                    Game.EventSystem.Publish(new EnemyKilledByHero() { unit = hero });
                }
            }
        }
    }
}