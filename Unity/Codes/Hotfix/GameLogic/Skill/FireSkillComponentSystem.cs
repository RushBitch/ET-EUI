using System;
using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    [Timer(TimerType.SkillDeltaTimer)]
    public class FireSkillTimer: ATimer<FireSkillComponent>
    {
        public override void Run(FireSkillComponent self)
        {
            try
            {
                self.Attack();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    public class FireSkillComponentDestorySystem: DestroySystem<FireSkillComponent>
    {
        public override void Destroy(FireSkillComponent self)
        {
            TimerComponent.Instance?.Remove(ref self.skillTimer);
        }
    }

    public static class FireSkillComponentSystem
    {
        public static async void StartAttack(this FireSkillComponent self)
        {
            self.skillTimer = TimerComponent.Instance.NewRepeatedTimer(self.deltaTime, TimerType.SkillDeltaTimer, self);
            await TimerComponent.Instance.WaitAsync(self.attackTime);
            self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
        }

        public static void Attack(this FireSkillComponent self)
        {
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            Unit hero = unitComponent.Get(self.heroId);
            if (hero ==null || hero.IsDisposed) return;
            Vector3 pos;
            if (hero.GetComponent<AttackComponent>().attackEnemy != null && !hero.GetComponent<AttackComponent>().attackEnemy.IsDisposed)
            {
                pos = hero.GetComponent<AttackComponent>().attackEnemy.Position;
            }
            else
            {
                pos = hero.GetComponent<AttackComponent>().skillPosition;
            }

            long heroDefenceId = hero.GetComponent<TowerDefenceIdComponent>().ID;
            List<Unit> units = new List<Unit>();
            foreach (var entity in unitComponent.Children.Values)
            {
                if (entity.IsDisposed)
                {
                    continue;
                }

                var unit = (Unit) entity;
                if (unit.GetComponent<MoveWithListComponent>() != null)
                {
                    if (unit.GetComponent<TowerDefenceIdComponent>()?.ID == heroDefenceId)
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
                if (units[i].GetComponent<LifeComponent>().preDead)
                {
                    continue;
                }

                units[i].GetComponent<LifeComponent>().PreAttacked(self.damage);
                bool isDead = units[i].GetComponent<LifeComponent>().Attacked(self.damage);
                if (isDead)
                {
                    Game.EventSystem.Publish(new EnemyKilledByHero() { id = self.towerDefenceID });
                }
            }
        }
    }
}