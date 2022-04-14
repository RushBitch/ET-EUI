using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateWeaponHandler: AEvent<AfterCreateWeapon>
    {
        protected override async ETTask Run(AfterCreateWeapon args)
        {
            if ((UnitType) args.unit.Config.Type == UnitType.CheetahWeapon)
            {
                ResourcesComponent.Instance.LoadBundle("Weapon.unity3d");
                GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Weapon.Unity3d", args.unit.Config.EngName);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
                LightningComponent lightningComponent = args.unit.AddComponent<LightningComponent, GameObject>(gameObject);

                Scene zoneScene = args.unit.DomainScene();
                long playerId = zoneScene.GetComponent<PlayerComponent>().MyId;
                TowerDefenceCompoment towerDefenceCompoment = zoneScene.GetComponent<TowerDefenceCompoment>();
                if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
                {
                    long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
                    TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(id);
                    if (towerDefence.playerIds.Contains(playerId))
                    {
                        lightningComponent.offset = new Vector3(0, 0, -4.25f);
                        lightningComponent.scale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        lightningComponent.offset = new Vector3(0, 0, 4.25f);
                        lightningComponent.scale = new Vector3(1, 1, -1);
                    }
                }

                lightningComponent.startPoint = Vector3.Scale(args.unit.GetComponent<WeaponComponent>().hero.Position, lightningComponent.scale) +
                        lightningComponent.offset;
                lightningComponent.endPoint = Vector3.Scale(args.unit.GetComponent<WeaponComponent>().hero.Position, lightningComponent.scale) +
                        lightningComponent.offset;
                lightningComponent.startPoint.y += 0.5f;
                lightningComponent.UpdateStartPos();
            }
            else
            {
                ResourcesComponent.Instance.LoadBundle("Weapon.unity3d");
                GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Weapon.Unity3d", args.unit.Config.EngName);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
                GameObjectComponent gameObjectComponent = args.unit.AddComponent<GameObjectComponent>();
                gameObjectComponent.GameObject = gameObject;
                PositionUpdateComponent positionUpdateComponent = args.unit.AddComponent<PositionUpdateComponent>();
                Scene zoneScene = args.unit.DomainScene();
                long playerId = zoneScene.GetComponent<PlayerComponent>().MyId;
                TowerDefenceCompoment towerDefenceCompoment = zoneScene.GetComponent<TowerDefenceCompoment>();
                if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
                {
                    long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
                    TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(id);
                    if (towerDefence.playerIds.Contains(playerId))
                    {
                        positionUpdateComponent.offset = new Vector3(0, 0, -4.25f);
                        positionUpdateComponent.scale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        positionUpdateComponent.offset = new Vector3(0, 0, 4.25f);
                        positionUpdateComponent.scale = new Vector3(1, 1, -1);
                    }
                }

                if (args.unit.GetComponent<WeaponComponent>() != null)
                {
                    if (args.unit.GetComponent<WeaponComponent>().enemy == null)
                    {
                        return;
                    }

                    GameObjectComponent enemyGb = args.unit.GetComponent<WeaponComponent>().enemy.GetComponent<GameObjectComponent>();
                    if (enemyGb != null)
                    {
                        gameObject.transform.position = TransformConvert.ConvertPositon(args.unit, args.unit.Position + new Vector3(0, 0.5f, 0));
                        gameObject.transform.LookAt(enemyGb.GameObject.transform.position);
                    }
                }

                ResourcesComponent.Instance.LoadBundle("Effect.unity3d");
                TrailEffectCompont trailEffectCompont;
                GameObject effect;
                GameObject gameObjecteffect;
                switch ((UnitType) args.unit.Config.Type)
                {
                    case UnitType.StoneBoyWeapon:
                    case UnitType.DrunkardWeapon:
                    case UnitType.AcrobatWeapon:
                        trailEffectCompont = args.unit.AddComponent<TrailEffectCompont>();
                        trailEffectCompont.followGameObject = gameObject;
                        effect = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", "NormalTrailEffect");
                        gameObjecteffect = UnityEngine.Object.Instantiate(effect, GlobalComponent.Instance.Unit);
                        trailEffectCompont.gameObject = gameObjecteffect;
                        break;
                    case UnitType.BuffaloWeapon:
                        trailEffectCompont = args.unit.AddComponent<TrailEffectCompont>();
                        trailEffectCompont.followGameObject = gameObject;
                        effect = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", "BuffaloTrailEffect");
                        gameObjecteffect = UnityEngine.Object.Instantiate(effect, GlobalComponent.Instance.Unit);
                        trailEffectCompont.gameObject = gameObjecteffect;
                        break;
                    case UnitType.FoxWeapon:
                        trailEffectCompont = args.unit.AddComponent<TrailEffectCompont>();
                        trailEffectCompont.followGameObject = gameObject;
                        effect = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", "FoxTrailEffect");
                        gameObjecteffect = UnityEngine.Object.Instantiate(effect, GlobalComponent.Instance.Unit);
                        trailEffectCompont.gameObject = gameObjecteffect;
                        break;
                    case UnitType.RebbitWeapon:
                        trailEffectCompont = args.unit.AddComponent<TrailEffectCompont>();
                        trailEffectCompont.followGameObject = gameObject;
                        effect = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", "RebbitTrailEffect");
                        gameObjecteffect = UnityEngine.Object.Instantiate(effect, GlobalComponent.Instance.Unit);
                        trailEffectCompont.gameObject = gameObjecteffect;
                        break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}