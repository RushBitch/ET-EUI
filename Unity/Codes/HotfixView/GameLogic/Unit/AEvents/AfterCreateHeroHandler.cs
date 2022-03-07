using System.Threading.Tasks;
using DG.Tweening;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateHeroHandler: AEvent<AfterCreateHero>
    {
        protected override async ETTask Run(AfterCreateHero args)
        {
            ResourcesComponent.Instance.LoadBundle("Hero.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Hero.Unity3d", args.unit.Config.EngName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
            GameObjectComponent gameObjectComponent = args.unit.AddComponent<GameObjectComponent>();
            gameObjectComponent.GameObject = gameObject;
            gameObject.transform.position = TransformConvert.ConvertPositon(args.unit, args.unit.Position);
            HeroLookAtEnemyComponent heroLookAtEnemyComponent = args.unit.AddComponent<HeroLookAtEnemyComponent>();
            Scene zoneScene = args.unit.DomainScene();
            long playerId = zoneScene.GetComponent<PlayerComponent>().MyId;
            TowerDefenceCompoment towerDefenceCompoment = zoneScene.GetComponent<TowerDefenceCompoment>();
            if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
            {
                long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(id);
                if (!towerDefence.playerIds.Contains(playerId))
                {
                    gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(1, 1, -1));
                    heroLookAtEnemyComponent.scaleOffset = new Vector3(-1, 1, 1);
                }
                else
                {
                    heroLookAtEnemyComponent.scaleOffset = new Vector3(1, 1, 1);
                }
            }

            AnimationComponent animationComponent = args.unit.AddComponent<AnimationComponent, GameObject>(gameObject);
            animationComponent.SetSpeed(args.unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed) / 20.0f);
            args.unit.AddComponent<HeroGreyComponent, Renderer>(gameObject.transform.GetChild(1).GetComponent<Renderer>());
            gameObject.transform.DOShakeScale(0.5f);

            ResourcesComponent.Instance.LoadBundle("levelFlag.unity3d");
            GameObject bundle3 = (GameObject) ResourcesComponent.Instance.GetAsset("levelFlag.unity3d",
                "LevelFlag" + args.unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Level));
            GameObject gameObject3 = UnityEngine.Object.Instantiate(bundle3, GlobalComponent.Instance.Unit);
            gameObject3.transform.position = gameObject.transform.position + new Vector3(-0.30f,0.1f,-0.25f);
            args.unit.AddComponent<LevelFlagComponent>().gameObject = gameObject3;
            Game.EventSystem.Publish(new PlayerEffect() { effectId = 1305, effectTime = 600, pos = gameObject.transform.position });
            if (args.unit.Config.Type == 7)
            {
                Transform transform = gameObject.transform.GetChild(2);
                gameObject.transform.localScale = gameObject.transform.localScale;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).localScale = gameObject.transform.localScale;
                }
            }

            await Task.CompletedTask;
        }
    }
}