using ET.EventType;

namespace ET
{
    public class EnemySpeedBuffEndHandler:AEvent<EventType.EnemySpeedBuffEnd>
    {
        protected override async ETTask Run(EnemySpeedBuffEnd a)
        {
            a.unit.GetComponent<MonsterMaterialConpoment>()?.BecomeNormal();
            await ETTask.CompletedTask;
        }
    }
}