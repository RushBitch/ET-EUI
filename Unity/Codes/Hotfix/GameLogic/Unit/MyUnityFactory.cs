using ET.EventType;

namespace ET
{
    public static class MyUnityFactory
    {
        public static Unit Create(Scene scene, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Enemy:
                    return CreateEnemy(unitComponent);
                case UnitType.Hero:
                    return CreateHero(unitComponent);
                case UnitType.Weapon:
                    return CreateWeapon(unitComponent);
            }

            return null;
        }

        private static Unit CreateEnemy(UnitComponent unitComponent)
        {
            Unit unit = unitComponent.AddChild<Unit>();
            unitComponent.Add(unit);
            unit.AddComponent<MoveWithListComponent>();
            NumericalComponent numericalComponent = unit.AddComponent<NumericalComponent>();
            numericalComponent.Set(NumericalType.SpeedBase, 1);
            numericalComponent.Set(NumericalType.HpBase, 100);
            numericalComponent.Set(NumericalType.PreHpBase, 100);
            unit.AddComponent<LifeComponent>();
            return unit;
        }
        
        private static Unit CreateHero(UnitComponent unitComponent)
        {
            Unit unit = unitComponent.AddChild<Unit>();
            unitComponent.Add(unit);
            unit.AddComponent<NumericalComponent>();
            return unit;
        }
        
        private static Unit CreateWeapon(UnitComponent unitComponent)
        {
            Unit unit = unitComponent.AddChild<Unit>();
            unitComponent.Add(unit);
            unit.AddComponent<NumericalComponent>();
            unit.AddComponent<AttackComponent>();
            return unit;
        }
    }
}