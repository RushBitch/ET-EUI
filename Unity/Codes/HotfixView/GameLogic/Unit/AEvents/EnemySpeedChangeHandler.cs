using UnityEngine;

namespace ET
{
    [NumericalWatcher(NumericalType.Speed)]
    public class EnemySpeedChangeHandler: INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Scene scene = ZoneSceneManagerComponent.Instance.Get(1);
            Unit unit = scene.GetComponent<UnitComponent>().Get(id);
            if (unit.GetComponent<MoveWithListComponent>() != null)
            {
                if (unit.GetComponent<AnimationComponent>() != null)
                {
                    foreach (AnimationState state in unit.GetComponent<AnimationComponent>().animation)
                    {
                        state.speed = value / 20f;
                    }
                }
            }
        }
    }
}