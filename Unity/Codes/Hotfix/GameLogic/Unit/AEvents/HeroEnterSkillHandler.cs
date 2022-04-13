using ET.EventType;
using UnityEngine;

namespace ET
{
    public class HeroExecuteSkillHandler: AEvent<HeroExecuteSkill>
    {
        protected async override ETTask Run(HeroExecuteSkill args)
        {
            switch ((UnitType) args.unit.Config.Type)
            {
                case UnitType.Drunkard:
                    this.DrunkardExetuceSkill(args.unit);
                    break;
                case UnitType.StoneBoy:
                    this.StoneBoyExetuceSkill(args.unit);
                    break;
                case UnitType.Acrobat:
                    this.AcrobatExetuceSkill(args.unit);
                    break;
                case UnitType.Peot:
                    this.PeotExetuceSkill(args.unit);
                    break;
                case UnitType.Master:
                    this.MasterExetuceSkill(args.unit);
                    break;
                case UnitType.Buffalo:
                    this.BuffaloExetuceSkill(args.unit);
                    break;
                case UnitType.Rebbit:
                    this.RebbitExetuceSkill(args.unit);
                    break;
            }

            await ETTask.CompletedTask;
        }

        private void DrunkardExetuceSkill(Unit unit)
        {
            SkillFactory.Create(unit);
        }

        private void StoneBoyExetuceSkill(Unit unit)
        {
            Unit weapon = WeaponFactory.Create(unit.DomainScene(), 1309, unit.GetComponent<TowerDefenceIdComponent>().ID,
                unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage),
                unit.GetComponent<AttackComponent>().attackEnemy, unit);
            weapon.GetComponent<WeaponComponent>().SetPosition(unit.Position + new Vector3(0, 0.5f, 0));
            weapon.GetComponent<WeaponComponent>().StartAttack();
        }

        private void AcrobatExetuceSkill(Unit unit)
        {
            unit.GetComponent<AddAttackSpeedSkillComponent>().Add();
        }

        private void PeotExetuceSkill(Unit unit)
        {
            unit.GetComponent<AddAttackDamageSkillComponent>().Add();
        }

        private void MasterExetuceSkill(Unit unit)
        {
            SkillFactory.Create(unit);
        }

        private void BuffaloExetuceSkill(Unit unit)
        {
            unit.GetComponent<AddAttackSpeedSkillComponent>().Add();
        }

        private void RebbitExetuceSkill(Unit unit)
        {
            SkillFactory.Create(unit);
        }
    }
}