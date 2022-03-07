using UnityEngine;

namespace ET
{
    [NumericalWatcher(NumericalType.HeroSpeed)]
    public class ChangeHeroSpeedHandler: INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Unit unit = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<UnitComponent>().Get(id);
            if (unit.GetComponent<AnimationComponent>() == null)
            {
                return;
            }

            unit.GetComponent<AnimationComponent>().SetSpeed(value/20);
        }
    }
}