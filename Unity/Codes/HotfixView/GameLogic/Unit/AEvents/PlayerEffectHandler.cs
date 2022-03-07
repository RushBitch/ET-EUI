using ET.EventType;
using UnityEngine;

namespace ET
{
    public class PlayerEffectHandler: AEvent<PlayerEffect>
    {
        protected override async ETTask Run(PlayerEffect args)
        {       
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            Unit unit = MyUnitFactory.Create(scene, args.effectId);
            EffectComponent effectComponent = unit.AddComponent<EffectComponent>();
            effectComponent.showTime = args.effectTime;
            ResourcesComponent.Instance.LoadBundle("Effect.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("Effect.unity3d", unit.Config.EngName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle, GlobalComponent.Instance.Unit);
            unit.AddComponent<GameObjectComponent>().GameObject = gameObject;
            gameObject.transform.position = args.pos;
            effectComponent.Start();
            await ETTask.CompletedTask;
        }
    }
}