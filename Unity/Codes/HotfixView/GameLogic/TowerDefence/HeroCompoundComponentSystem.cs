using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET
{
    public class HeroCompoundComponentAwakeSystem: AwakeSystem<HeroCompoundComponent>
    {
        public override void Awake(HeroCompoundComponent self)
        {
            self.sellectUnit = null;
        }
    }

    public static class HeroCompoundComponentSystem
    {
        public static void onTouchStart(this HeroCompoundComponent self, PointerEventData pointerEventData)
        {
            Ray ray = self.ZoneScene().GetComponent<MainCameraComponent>().camera.ScreenPointToRay(pointerEventData.position);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                return;
            }

            UnitComponent unitComponent = self.ZoneScene().GetComponent<UnitComponent>();
            long myId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;
            self.ZoneScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            float maxDistance = Int32.MaxValue;
            Unit closetUnit = null;
            foreach (var unit in unitComponent.Children.Values)
            {
                if (unit.GetComponent<AttackComponent>() == null)
                {
                    continue;
                }

                if (unit.GetComponent<TowerDefenceIdComponent>().ID != towerDefence.Id)
                {
                    continue;
                }

                float tempDistance = Vector3.Distance(unit.GetComponent<GameObjectComponent>().GameObject.transform.position,
                    hitInfo.point);
                if (!(maxDistance > tempDistance))
                {
                    continue;
                }

                maxDistance = tempDistance;
                closetUnit = (Unit) unit;
            }

            if (closetUnit != null)
            {
                self.sellectUnit = closetUnit;
                self.sellectUnit.GetComponent<UnitStateComponent>().unitState = UnitState.Idle;
                StartCompoundUnit(self.sellectUnit);
            }
        }

        public static void onTouchMove(this HeroCompoundComponent self, PointerEventData pointerEventData)
        {
            if (self.sellectUnit == null)
            {
                return;
            }

            Ray ray = self.ZoneScene().GetComponent<MainCameraComponent>().camera.ScreenPointToRay(pointerEventData.position);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                self.sellectUnit.GetComponent<GameObjectComponent>().GameObject.transform.position = hitInfo.point;
            }
        }

        public static void onTouchEnd(this HeroCompoundComponent self, PointerEventData pointerEventData)
        {
            if (self.sellectUnit == null)
            {
                return;
            }

            Ray ray = self.ZoneScene().GetComponent<MainCameraComponent>().camera.ScreenPointToRay(pointerEventData.position);
            if (!Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                return;
            }

            UnitComponent unitComponent = self.ZoneScene().GetComponent<UnitComponent>();
            long myId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;
            self.ZoneScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            float maxDistance = Int32.MaxValue;
            Unit closetUnit = null;
            foreach (var unit in unitComponent.Children.Values)
            {
                if (unit.GetComponent<AttackComponent>() == null)
                {
                    continue;
                }

                if (unit.GetComponent<TowerDefenceIdComponent>().ID != towerDefence.Id)
                {
                    continue;
                }

                if (unit == self.sellectUnit)
                {
                    continue;
                }

                float tempDistance = Vector3.Distance(unit.GetComponent<GameObjectComponent>().GameObject.transform.position,
                    hitInfo.point);
                if (!(maxDistance > tempDistance))
                {
                    continue;
                }

                maxDistance = tempDistance;
                closetUnit = (Unit) unit;
            }

            if (closetUnit != null && maxDistance <= 1 && IsCanCpompound(self.sellectUnit, closetUnit))
            {
                self.CompoundUnit(self.sellectUnit, closetUnit);
            }
            else
            {
                self.sellectUnit.GetComponent<GameObjectComponent>().GameObject.transform.position =
                        TransformConvert.ConvertPositon(self.sellectUnit, self.sellectUnit.Position);
                self.sellectUnit.GetComponent<UnitStateComponent>().unitState = UnitState.Attack;
            }

            EndCompoundUnit(self.ZoneScene());
            self.sellectUnit = null;
        }

        private static void CompoundUnit(this HeroCompoundComponent self, Unit unit1, Unit unit2)
        {
            long myId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;
            self.ZoneScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            int index = unit2.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroIndex);
            int level = unit2.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Level);
            towerDefence.GetComponent<HeroSpawnComponent>().Remove(myId, unit1);
            towerDefence.GetComponent<HeroSpawnComponent>().Remove(myId, unit2);
            self.ZoneScene().GetComponent<UnitComponent>().Remove(unit1.Id);
            self.ZoneScene().GetComponent<UnitComponent>().Remove(unit2.Id);
            towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHeroWithIndex(myId, index, level);
        }

        private static void StartCompoundUnit(Unit sellectUnit)
        {
            UnitComponent unitComponent = sellectUnit.ZoneScene().GetComponent<UnitComponent>();
            long myId = sellectUnit.ZoneScene().GetComponent<PlayerComponent>().MyId;
            sellectUnit.ZoneScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            foreach (Unit unit in unitComponent.Children.Values)
            {
                if (unit.GetComponent<AttackComponent>() == null)
                {
                    continue;
                }

                if (unit.GetComponent<TowerDefenceIdComponent>().ID != towerDefence.Id)
                {
                    continue;
                }

                if (unit == sellectUnit)
                {
                    continue;
                }

                if (IsCanCpompound(unit, sellectUnit))
                {
                    unit.GetComponent<HeroComboundPlaneCompoment>()?.Show();
                    continue;
                }
                unit.GetComponent<LevelFlagComponent>()?.Hide();
                unit.GetComponent<HeroGreyComponent>().BecomeGrey();
            }
        }

        private static bool IsCanCpompound(Unit unit1, Unit unit2)
        {
            if (unit1.Config.Type == unit2.Config.Type)
            {
                if (unit1.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Level) ==
                    unit2.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Level))
                {
                    return true;
                }
            }

            return false;
        }

        private static void EndCompoundUnit(Scene scene)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            long myId = scene.GetComponent<PlayerComponent>().MyId;
            scene.GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            foreach (Unit unit in unitComponent.Children.Values)
            {
                if (unit.GetComponent<AttackComponent>() == null)
                {
                    continue;
                }

                if (unit.GetComponent<TowerDefenceIdComponent>().ID != towerDefence.Id)
                {
                    continue;
                }

                unit.GetComponent<HeroGreyComponent>().BecomeNormal();
                unit.GetComponent<HeroComboundPlaneCompoment>()?.Hide();
                unit.GetComponent<LevelFlagComponent>()?.Show();
            }
        }
    }
}