using System;
using ET.EventType;

namespace ET
{
    public static class MyUnitFactory
    {
        public static Unit Create(Scene scene, int configId)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChild<Unit, int>(configId);
            unitComponent.Add(unit);
            unit.AddComponent<NumericalComponent>();
            UnitType unitType = (UnitType)unit.Config.Type;
            switch (unitType)
            {
                case UnitType.Boss:
                    return ConfigBoss(unit);
                case UnitType.Monster:
                    return ConfigMonster(unit);
                case UnitType.Warrior:
                    return ConfigWarrior(unit);
                case UnitType.Drunkard:
                    return ConfigDrunkard(unit);
                case UnitType.StoneBoy:
                    return ConfigStoneBoy(unit);
                case UnitType.Acrobat:
                    return ConfigAcrobat(unit);
                case UnitType.Master:
                    return ConfigMaster(unit);
                case UnitType.Peot:
                    return ConfigPeot(unit);
                case UnitType.Buffalo:
                    return ConfigBuffalo(unit);
                case UnitType.Fox:
                    return ConfigFox(unit);
                case UnitType.Rebbit:
                    return ConfigRebbit(unit);
                case UnitType.DrunkardSkill:
                    return ConfigDrunkardSkill(unit);
                case UnitType.StoneBoySkill:
                    return ConfigStoneBoySkill(unit);
                case UnitType.MasterSkill:
                    return ConfigMasterSkill(unit);
                case UnitType.RebbitSkill:
                    return ConfigRebbitSkill(unit);
            }

            return unit;
        }

        private static Unit ConfigBoss(Unit unit)
        {
            return unit;
        }

        private static Unit ConfigMonster(Unit unit)
        {
            return unit;
        }

        private static Unit ConfigWarrior(Unit unit)
        {
            return unit;
        }

        private static Unit ConfigDrunkard(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            unit.AddComponent<AttackCountAIComponent>();
            return unit;
        }

        private static Unit ConfigStoneBoy(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            unit.AddComponent<AttackCountAIComponent>();
            return unit;
        }

        private static Unit ConfigAcrobat(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            unit.GetComponent<NumericalComponent>().Set(NumericalType.DeltaTimeToSkillBase, heroConfig.DeltaTimeToSkill);
            unit.AddComponent<DeltaTimeAIComponent>();
            unit.AddComponent<AddAttackSpeedSkillComponent>();
            return unit;
        }

        private static Unit ConfigMaster(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            unit.GetComponent<NumericalComponent>().Set(NumericalType.DeltaTimeToSkillBase, heroConfig.DeltaTimeToSkill);
            unit.AddComponent<DeltaTimeAIComponent>();
            return unit;
        }

        private static Unit ConfigPeot(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            unit.GetComponent<NumericalComponent>().Set(NumericalType.DeltaTimeToSkillBase, heroConfig.DeltaTimeToSkill);
            unit.AddComponent<DeltaTimeAIComponent>();
            unit.AddComponent<AddAttackDamageSkillComponent>();
            return unit;
        }

        private static Unit ConfigDrunkardSkill(Unit unit)
        {
            unit.AddComponent<FireSkillComponent>();
            return unit;
        }

        private static Unit ConfigStoneBoySkill(Unit unit)
        {
            unit.AddComponent<StoneSkillComponent>();
            return unit;
        }
        
        private static Unit ConfigMasterSkill(Unit unit)
        {
            unit.AddComponent<SnowStormSkillComponent>();
            return unit;
        }

        private static Unit ConfigBuffalo(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            unit.GetComponent<NumericalComponent>().Set(NumericalType.DeltaTimeToSkillBase, heroConfig.DeltaTimeToSkill);
            unit.AddComponent<DeltaTimeAIComponent>();
            unit.AddComponent<AddAttackSpeedSkillComponent>();
            return unit;
        }
        private static Unit ConfigFox(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            return unit;
        }
        
        private static Unit ConfigRebbit(Unit unit)
        {
            UnitStateComponent unitStateComponent = unit.AddComponent<UnitStateComponent>();
            unitStateComponent.unitState = UnitState.Attack;
            unit.AddComponent<AttackCountAIComponent>();
            return unit;
        }
        
        private static Unit ConfigRebbitSkill(Unit unit)
        {
            unit.AddComponent<RebbitSkillComponent>();
            return unit;
        }
        private static Unit ConfigNull(Unit unit)
        {
            return unit;
        }
    }
}