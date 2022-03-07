using DG.Tweening;
using ET.EventType;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class AfterCreateEnemyHandler: AEvent<AfterCreateEnemy>
    {
        protected override async ETTask Run(AfterCreateEnemy args)
        {
            ResourcesComponent.Instance.LoadBundle("Enemy.unity3d");
            UnityEngine.Object bundle = ResourcesComponent.Instance.GetAsset("Enemy.unity3d", args.unit.Config.EngName);
            GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
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
                    transformUpdateComponent.scale =  new Vector3(1, 1, 1);
                }
                else
                {
                    transformUpdateComponent.offset = new Vector3(0, 0, 4.25f);
                    transformUpdateComponent.scale = new Vector3(1, 1, -1);
                    gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(1, 1, -1));
                }
            }
            ResourcesComponent.Instance.LoadBundle("ui.unity3d");
            GameObject bundle1 = (GameObject) ResourcesComponent.Instance.GetAsset("ui.unity3d", "EnemyHpLabel");
            GameObject gameObject1 = UnityEngine.Object.Instantiate(bundle1, GlobalComponent.Instance.OtherRoot);
            EnemyHpViewComponent enemyHpViewComponent = args.unit.AddComponent<EnemyHpViewComponent>();
            enemyHpViewComponent.gameObject = gameObject1;
            gameObject1.GetComponent<Text>().text = args.unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Hp).ToString();
            gameObject1.transform.DOShakeScale(0.3f);
            AnimationComponent animationComponent =  args.unit.AddComponent<AnimationComponent, GameObject>(gameObject);
            animationComponent.CrossFade(AnimType.走路);

            args.unit.AddComponent<MonsterMaterialConpoment,GameObject>(gameObject);
            
            
            
            await ETTask.CompletedTask;
        }
    }
}