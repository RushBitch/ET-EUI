namespace ET
{
    public class EnemySpeedBuffComponent:Entity,IAwake<int,long>, IDestroy, IUpdate
    {
        public long endTime;
        public int addition;
    }
}