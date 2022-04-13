using ET.EventType;
using UnityEngine;

namespace ET
{
    public class HeroEnterSkillReadyHandler: AEvent<HeroEnterSkillReady>
    {
        protected async override ETTask Run(HeroEnterSkillReady args)
        {
            switch ((UnitType) args.unit.Config.Type)
            {
                case UnitType.Drunkard:
                    this.DrunkardEnterSkillReady(args.unit);
                    break;
                case UnitType.StoneBoy:
                    this.StoneBoyEnterSkillReady(args.unit);
                    break;
                case UnitType.Rebbit:
                    this.RebbitEnterSkillReady(args.unit);
                    break;
            }

            await ETTask.CompletedTask;
        }

        private void DrunkardEnterSkillReady(Unit unit)
        {
            long id = unit.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = unit.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);

            Unit enemy = towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit;

            if (enemy != null && Vector3.Distance(unit.Position, enemy.Position)<=3)
            {
                unit.GetComponent<AttackComponent>().attackEnemy = enemy;
                unit.GetComponent<AttackComponent>().canExeuteSkill = true;
                unit.GetComponent<AttackComponent>().skillPosition = enemy.Position;
            }
            else
            {
                unit.GetComponent<AttackComponent>().attackEnemy = null;
                unit.GetComponent<AttackComponent>().canExeuteSkill = false;
            }
        }

        private void StoneBoyEnterSkillReady(Unit unit)
        {
            long id = unit.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = unit.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);

            Unit enemy = towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit;

            if (enemy != null)
            {
                int damage = unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
                //enemy.GetComponent<LifeComponent>().PreAttacked(damage);
                unit.GetComponent<AttackComponent>().attackEnemy = enemy;
                unit.GetComponent<AttackComponent>().canExeuteSkill = true;
                unit.GetComponent<AttackComponent>().skillPosition = enemy.Position;
            }
            else
            {
                unit.GetComponent<AttackComponent>().attackEnemy = null;
                unit.GetComponent<AttackComponent>().canExeuteSkill = false;
            }
        }
        
        private void RebbitEnterSkillReady(Unit unit)
        {
            long id = unit.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = unit.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);

            Unit enemy = towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit;

            if (enemy != null)
            {
                //int damage = unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
                //enemy.GetComponent<LifeComponent>().PreAttacked(damage);
                unit.GetComponent<AttackComponent>().attackEnemy = enemy;
                unit.GetComponent<AttackComponent>().canExeuteSkill = true;
                unit.GetComponent<AttackComponent>().skillPosition = enemy.Position;
            }
            else
            {
                unit.GetComponent<AttackComponent>().attackEnemy = null;
                unit.GetComponent<AttackComponent>().canExeuteSkill = false;
            }
        }
    }
}