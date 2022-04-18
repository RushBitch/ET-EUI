using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterDestoryWeaponHandler: AEvent<AfterDestroyWeapon>
    {
        protected override async ETTask Run(AfterDestroyWeapon args)
        {
            int configId = 0;
            int effectTime = 0;
            Vector3 pos = Vector3.zero;
            if (args.unit.GetComponent<WeaponComponent>().enemy == null)
            {
                return;
            }
            if (args.unit.GetComponent<WeaponComponent>().enemy.IsDisposed)
            {
                return;
            }
            if (args.unit.GetComponent<GameObjectComponent>() != null)
            {
                pos = args.unit.GetComponent<GameObjectComponent>().GameObject.transform.position;
            }
            switch ((UnitType) args.unit.Config.Type)
            {
                case UnitType.StoneBoyWeapon:
                case UnitType.AcrobatWeapon:
                case UnitType.MasterWeapon:
                case UnitType.BuffaloWeapon:
                case UnitType.FoxWeapon:
                case UnitType.RebbitWeapon:
                case UnitType.BlackCatWeapon:
                    configId = 1303;
                    effectTime = 300;
                    break;
                case UnitType.DrunkardWeapon:
                    configId = 1304;
                    effectTime = 300;
                    break;
                case UnitType.StoneBoySkillWeapon:
                    configId = 1302;
                    effectTime = 1100;
                    pos.y = 0;
                    break;
                case UnitType.CheetahWeapon:
                    configId = 1314;
                    effectTime = 500;
                    pos = args.unit.GetComponent<LightningComponent>().endPoint;
                    pos.y = 0.3f;
                    break;
            }

            if (configId == 0)
            {
                return;
            }
            Game.EventSystem.Publish(new PlayerEffect() { effectId = configId, effectTime = effectTime, pos = pos });
            await ETTask.CompletedTask;
        }
    }
}