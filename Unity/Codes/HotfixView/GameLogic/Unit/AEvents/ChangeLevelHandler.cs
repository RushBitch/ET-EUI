namespace ET
{
    [NumericalWatcher(NumericalType.Level)]
    public class ChangeLevelHandler: INumericalWatcher
    {
        public void Run(long id, long value)
        {
            Unit unit = ZoneSceneManagerComponent.Instance.Get(1).GetComponent<UnitComponent>().Get(id);
            NumericalComponent numericalComponent = unit.GetComponent<NumericalComponent>();
            numericalComponent.Set(NumericalType.HeroDamageBase, unit.Config.Damage * value);
        }
    }
}