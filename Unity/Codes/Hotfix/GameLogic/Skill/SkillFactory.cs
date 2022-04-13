using System;
using ET.EventType;
using UnityEngine;

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
                case UnitType.RebbitSkill:
                    ConfigRebbitSkill(unit, skill);
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
            fireSkillComponent.towerDefenceID = hero.GetComponent<TowerDefenceIdComponent>().ID;
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
            fireSkillComponent.towerDefenceID = hero.GetComponent<TowerDefenceIdComponent>().ID;
            fireSkillComponent.StartAttack();
            return skill;
        }

        private static Unit ConfigRebbitSkill(Unit hero, Unit skill)
        {
            RebbitSkillComponent rebbitSkillComponent = skill.GetComponent<RebbitSkillComponent>();
            rebbitSkillComponent.attackRange = 1.2f;
            rebbitSkillComponent.damage = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage) * 2;
            rebbitSkillComponent.hero = hero;
            rebbitSkillComponent.speed = skill.Config.Speed;
            rebbitSkillComponent.enemyPosition = hero.GetComponent<AttackComponent>().attackEnemy.Position;
            rebbitSkillComponent.towerDefenceId = hero.GetComponent<TowerDefenceIdComponent>().ID;
            skill.Position = hero.Position + new Vector3(0,0.5f,0);
            rebbitSkillComponent.StartAttack();
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