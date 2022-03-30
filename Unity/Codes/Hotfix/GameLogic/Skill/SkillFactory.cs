using System;
using ET.EventType;

namespace ET
{
    public static class SkillFactory
    {
        public static Unit Create(Unit unit)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            Unit skill = MyUnitFactory.Create(scene, unit.Config.SkillId);
            skill.AddComponent<TowerDefenceIdComponent, long>(unit.GetComponent<TowerDefenceIdComponent>().ID);
            switch ((UnitType) skill.Config.Type)
            {
                case UnitType.DrunkardSkill:
                    ConfigDrunkardSkill(unit, skill);
                    break;
                case UnitType.StoneBoySkill:
                    ConfigStoneBoySkill(unit, skill);
                    break;
                case UnitType.MasterSkill:
                    ConfigMasterSkill(unit, skill);
                    break;
            }

            Game.EventSystem.Publish(new AfterCreateSkill() { unit = skill });
            return skill;
        }

        private static Unit ConfigDrunkardSkill(Unit hero, Unit skill)
        {
            FireSkillComponent fireSkillComponent = skill.GetComponent<FireSkillComponent>();
            fireSkillComponent.attackRange = 0.9f;
            fireSkillComponent.damage = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
            fireSkillComponent.attackTime = 1000;
            fireSkillComponent.deltaTime = 200;
            fireSkillComponent.heroId = hero.Id;
            skill.Position = hero.Position;
            fireSkillComponent.StartAttack();
            return skill;
        }

        private static Unit ConfigStoneBoySkill(Unit hero, Unit skill)
        {
            StoneSkillComponent fireSkillComponent = skill.GetComponent<StoneSkillComponent>();
            fireSkillComponent.attackRange = 1.2f;
            fireSkillComponent.damage = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
            fireSkillComponent.attackTime = 500;
            fireSkillComponent.heroId = hero.Id;
            fireSkillComponent.StartAttack();
            return skill;
        }

        private static Unit ConfigMasterSkill(Unit hero, Unit skill)
        {
            SnowStormSkillComponent snowStormSkillComponent = skill.GetComponent<SnowStormSkillComponent>();
            snowStormSkillComponent.showtime = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.SkillShowTime);
            snowStormSkillComponent.slowSpeed = 1;
            snowStormSkillComponent.durationTime = 2000;
            snowStormSkillComponent.defenceID = hero.GetComponent<TowerDefenceIdComponent>().ID;
            snowStormSkillComponent.Start();
            return skill;
        }
    }
}