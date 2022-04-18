using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class CheetahExtraAttackComponentAwakeSystem: AwakeSystem<CheetahExtraAttackComponent>
    {
        public override void Awake(CheetahExtraAttackComponent self)
        {
            self.enemys = new List<Unit>();
        }
    }

    public static class CheetahExtraAttackComponentSystem
    {
        public static void PreAttack(this CheetahExtraAttackComponent self, Unit enemy, int damage)
        {
            self.enemys.Clear();
            if (self.IsDisposed || self.Parent.IsDisposed) return;
            if (enemy.IsDisposed) return;
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            List<Unit> units = new List<Unit>();
            long heroTowerDefenceID = self.Parent.GetComponent<TowerDefenceIdComponent>().ID;
            foreach (var unit in unitComponent.Children.Values)
            {
                if (unit == null || unit.IsDisposed || unit.Id == enemy.Id)
                {
                    continue;
                }

                if (unit.GetComponent<MoveWithListComponent>() == null) continue;
                if (unit.GetComponent<TowerDefenceIdComponent>().ID != heroTowerDefenceID) continue;
                if (unit.GetComponent<LifeComponent>().preDead || unit.GetComponent<LifeComponent>().dead) continue;
                units.Add((Unit) unit);
            }

            units.Sort((unit1, unit2) =>
            {
                float dis1 = Vector3.Distance(unit1.Position, enemy.Position);
                float dis2 = Vector3.Distance(unit2.Position, enemy.Position);
                if (dis1 > dis2)
                    return 1;
                else if (Math.Abs(dis1 - dis2) < 0.001f)
                    return 0;
                else
                    return -1;
            });

            int level = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Level);
            int currentIndex = 1;
            foreach (var unit in units)
            {
                if (currentIndex >= level) break;
                unit.GetComponent<LifeComponent>().PreAttacked(damage);
                self.enemys.Add(unit);
                currentIndex += 1;
            }

            //Log.Info($"额外的敌人：{self.enemys.Count}");
        }
    }
}