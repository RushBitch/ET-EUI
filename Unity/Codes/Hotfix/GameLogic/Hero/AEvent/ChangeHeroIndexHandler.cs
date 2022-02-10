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
            unit.Position = new Vector3(value % 7 - 3, 0, value / 7 - 5);
            Game.EventSystem.Publish(new ChangeHeroPosition() { unit = unit });
        }
    }
}