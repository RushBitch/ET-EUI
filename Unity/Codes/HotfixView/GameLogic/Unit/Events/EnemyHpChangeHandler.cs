using UnityEngine.UI;

namespace ET
{
    [NumericalWatcher(NumericalType.Hp)]
    public class EnemyHpChangeHandler : INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Unit unit = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<UnitComponent>().Get(id);
            EnemyHpViewComponent enemyHpViewComponent = unit.GetComponent<EnemyHpViewComponent>();
            if (enemyHpViewComponent != null)
            {
                enemyHpViewComponent.gameObject.GetComponent<Text>().text = value.ToString();
            }
        }
    }
}