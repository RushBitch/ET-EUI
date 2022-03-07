namespace ET
{
    public enum UnitState
    {
        Idle,
        Attack,
        Skill
    }

    public class UnitStateComponent:Entity, IAwake
    {
        public UnitState unitState;
    }
}