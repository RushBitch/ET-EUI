using ET.EventType;

namespace ET
{
    public class EnemySpeedBuffStartHandler:AEvent<EventType.EnemySpeedBuffStart>
    {
        protected override async ETTask Run(EnemySpeedBuffStart a)
        {
            a.unit.GetComponent<MonsterMaterialConpoment>()?.BecomeForest();
            await ETTask.CompletedTask;
        }
    }
}