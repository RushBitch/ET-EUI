using ET.EventType;
using UnityEngine;

namespace ET
{
    public class ChangeHeroPositionHandler: AEvent<ChangeHeroPosition>
    {
        protected override async ETTask Run(ChangeHeroPosition args)
        {
            GameObjectComponent gameObjectComponent = args.unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent != null)
            {
                args.unit.GetComponent<GameObjectComponent>().GameObject.transform.position =
                        TransformConvert.ConvertPositon(args.unit, args.unit.Position);
            }
            
            await ETTask.CompletedTask;
        }
    }
}