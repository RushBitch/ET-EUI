﻿using ET.EventType;

namespace ET
{
    public class CleanMaxMoveDistanceHandler: AEvent<CleanMaxMoveDistance>
    {
        protected override async ETTask Run(CleanMaxMoveDistance args)
        {
            // if ((UnitType)args.unit.Config.Type == UnitType.Boss)
            // {
            //     Log.Info("清除boss的记录");
            // }
            long id = args.unit.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = args.unit.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);
            if (towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit == args.unit)
            {
                // if ((UnitType)args.unit.Config.Type == UnitType.Boss)
                // {
                //     Log.Info("清除boss的记录了");
                // }
                //Log.Info($"清除预攻击对象：{args.unit.Id}");
                towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit = null;
                towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().maxDistance = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}