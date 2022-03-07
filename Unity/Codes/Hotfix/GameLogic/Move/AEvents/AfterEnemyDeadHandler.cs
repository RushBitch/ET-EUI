using ET.EventType;

namespace ET.AEvents
{
    public class AfterEnemyDeadHandler: AEvent<AfterEnemyDead>
    {
        protected async override ETTask Run(AfterEnemyDead args)
        {
            args.unit.GetComponent<MoveWithListComponent>()?.Dispose();
            await ETTask.CompletedTask;
        }
    }
}