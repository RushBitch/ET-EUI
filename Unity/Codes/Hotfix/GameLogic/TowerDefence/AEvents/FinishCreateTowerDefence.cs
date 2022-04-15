namespace ET
{
    public class FinishCreateTowerDefence:AEvent<EventType.FinishCreateTowerDefence>
    {
        protected override async ETTask Run(EventType.FinishCreateTowerDefence args)
        {
            
            await ETTask.CompletedTask;
        }
    }
}