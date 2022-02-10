using System.Threading.Tasks;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class AfterCreateHeroHandler: AEvent<AfterCreateHero>
    {
        protected override async ETTask Run(AfterCreateHero args)
        {
            ResourcesComponent.Instance.LoadBundle("Hero.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Hero.Unity3d", "Acrobat");
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

            await Task.CompletedTask;
        }
    }
}