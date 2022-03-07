using DG.Tweening;
using ET.EventType;

namespace ET
{
    public class AfterEnemyDeadHandler:AEvent<AfterEnemyDead>
    {
        protected async override ETTask Run(AfterEnemyDead args)
        {
            args.unit.GetComponent<TransformUpdateComponent>().Dispose();
            AnimationComponent animationComponent =  args.unit.GetComponent<AnimationComponent>();
            animationComponent.Play(AnimType.死亡);
            await TimerComponent.Instance.WaitAsync(1500);
            args.unit.GetComponent<GameObjectComponent>().GameObject.transform.DOMoveY(-1,2.5f);
            await ETTask.CompletedTask;
        }
    }
}