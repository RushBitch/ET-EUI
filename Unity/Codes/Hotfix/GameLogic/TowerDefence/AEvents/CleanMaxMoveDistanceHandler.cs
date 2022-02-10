using ET.EventType;

namespace ET
{
    public class CleanMaxMoveDistanceHandler: AEvent<CleanMaxMoveDistance>
    {
        protected override async ETTask Run(CleanMaxMoveDistance args)
        {
            long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = args.unit.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
            if (towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit == args.unit)
            {
                towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit = null;
                towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().maxDistance = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}