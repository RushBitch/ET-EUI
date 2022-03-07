﻿using ET.EventType;

namespace ET
{
    public static class EnemyFactory
    {
        public static Unit Create(Scene scene, int configId, long towerDefenceID)
        {
            Unit unit = MyUnitFactory.Create(scene, configId);
            unit.AddComponent<MoveWithListComponent>();
            NumericalComponent numericalComponent = unit.GetComponent<NumericalComponent>();
            numericalComponent.Set(NumericalType.SpeedBase, unit.Config.Speed);
            CountDownComponent countDownComponent = scene.GetComponent<TowerDefenceCompoment>().GetComponent<CountDownComponent>();
            //Log.Info(countDownComponent.additionCount / 3 * 10);
            numericalComponent.Set(NumericalType.HpBase,
                unit.Config.HPBase +  countDownComponent.additionCount / 3 * 10);
            numericalComponent.Set(NumericalType.PreHpBase, unit.Config.HPBase);
            unit.AddComponent<LifeComponent>();
            MoveWithListComponent moveWithListComponent = unit.GetComponent<MoveWithListComponent>();
            if (moveWithListComponent != null)
            {
                moveWithListComponent.recordMaxMoveDistanceComponent =
                        scene.GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(towerDefenceID)
                                .GetComponent<RecordMaxMoveDistanceComponent>();
            }

            unit.AddComponent<TowerDefenceIdComponent, long>(towerDefenceID);
            Game.EventSystem.Publish(new AfterCreateEnemy() { unit = unit });
            return unit;
        }
    }
}