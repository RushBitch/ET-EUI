using ET.EventType;
using UnityEngine;

namespace ET
{
    [NumericalWatcher(NumericalType.HeroIndex)]
    public class ChangeHeroIndexHandler: INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Unit unit = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<UnitComponent>().Get(id);
            long playerId = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<PlayerComponent>().MyId;
            float offset = 0;
            TowerDefenceCompoment towerDefenceCompoment = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<TowerDefenceCompoment>();
            if (towerDefenceCompoment.towerDefenceMode == TowerDefenceMode.Pvp)
            {
                long Id = unit.GetComponent<TowerDefenceIdComponent>().ID;
                TowerDefence towerDefence = towerDefenceCompoment.GetChild<TowerDefence>(Id);
                if (!towerDefence.playerIds.Contains(playerId))
                {
                    offset = -0.4f;
                }
                else
                {
                    offset = 0f;
                }
            }

            unit.Position = new Vector3(value % 7 - 2.5f, 0f, value / 7 - 4.4f + (value / 7 - 2.5f) * 0f - offset);
            Game.EventSystem.Publish(new ChangeHeroPosition() { unit = unit });
        }
    }
}