using ET.EventType;
using UnityEngine;

namespace ET
{
    public class HeroExecuteAttackHandler: AEvent<HeroExecuteAttack>
    {
        protected override async ETTask Run(HeroExecuteAttack args)
        {
            switch ((UnitType) args.unit.Config.Type)
            {
                case UnitType.Drunkard:
                case UnitType.StoneBoy:
                case UnitType.Acrobat:
                case UnitType.Master:
                case UnitType.Buffalo:
                case UnitType.Fox:
                case UnitType.Rebbit:
                    ExectueNormalAttack(args.unit);
                    break;
            }
            await ETTask.CompletedTask;
        }

        private void ExectueNormalAttack(Unit unit)
        {
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(unit.Config.Type);
            Unit weapon = WeaponFactory.Create(unit.DomainScene(), heroConfig.WeaponId, unit.GetComponent<TowerDefenceIdComponent>().ID,
                unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage),
                unit.GetComponent<AttackComponent>().attackEnemy, unit);
            weapon.GetComponent<WeaponComponent>().SetPosition(unit.Position + new Vector3(0, 0.5f, 0));
            weapon.GetComponent<WeaponComponent>().StartAttack();
        }
    }
}