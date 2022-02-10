using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateWeaponHandler:AEvent<AfterCreateWeapon>
    {
        protected override async ETTask Run(AfterCreateWeapon args)
        {
            ResourcesComponent.Instance.LoadBundle("Weapon.unity3d");
            GameObject bundle = (GameObject)ResourcesComponent.Instance.GetAsset("Weapon.Unity3d", "Null");
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle,GlobalComponent.Instance.Unit);
            GameObjectComponent gameObjectComponent = args.unit.AddComponent<GameObjectComponent>();
            gameObjectComponent.GameObject = gameObject;
            
            TransformUpdateComponent transformUpdateComponent = args.unit.AddComponent<TransformUpdateComponent>();
            Scene zoneScene = args.unit.DomainScene();
            long playerId = zoneScene.GetComponent<PlayerComponent>().MyId;
            TowerDefenceCompoment towerDefenceCompoment = zoneScene.GetComponent<TowerDefenceCompoment>();
            if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
            {
                long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(id);
                if (towerDefence.playerIds.Contains(playerId))
                {
                    transformUpdateComponent.offset = new Vector3(0, 0, -4.25f);
                    transformUpdateComponent.scale = new Vector3(1, 1, 1);
                }
                else
                {
                    transformUpdateComponent.offset = new Vector3(0, 0, 4.25f);
                    transformUpdateComponent.scale = new Vector3(1, 1, -1);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}