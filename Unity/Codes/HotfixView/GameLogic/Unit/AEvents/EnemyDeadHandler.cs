using DG.Tweening;
using ET.EventType;

namespace ET
{
    public class AfterEnemyDeadHandler: AEvent<AfterEnemyDead>
    {
        protected async override ETTask Run(AfterEnemyDead args)
        {
            args.unit.GetComponent<TransformUpdateComponent>().Dispose();
            if (args.unit.Config.Type == (int) UnitType.Boss)
            {
                AnimationComponent animationComponent = args.unit.GetComponent<AnimationComponent>();
                animationComponent.SetSpeed(0.25f);
                animationComponent.Play(AnimType.死亡);
                SoundComponent.Instance.Play(Sound.Boss吼叫);
                await TimerComponent.Instance.WaitAsync(1300);
                Game.EventSystem.Publish(new PlayerEffect()
                {
                    effectId = 1315, effectTime = 2000, pos = args.unit.GetComponent<GameObjectComponent>().GameObject.transform.position
                });
                SoundComponent.Instance.Play(Sound.Boss消失音效);
                //await TimerComponent.Instance.WaitAsync(200);
                //args.unit.GetComponent<GameObjectComponent>().GameObject.transform.DOMoveY(-1, 2.5f);
            }
            // else
            // {
            //     Game.EventSystem.Publish(new PlayerEffect() { effectId = 1311
            //         , effectTime = 500, pos = args.unit.GetComponent<GameObjectComponent>().GameObject.transform.position });
            // }

            await ETTask.CompletedTask;
        }
    }
}