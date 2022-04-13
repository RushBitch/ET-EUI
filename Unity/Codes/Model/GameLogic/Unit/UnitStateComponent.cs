namespace ET
{
    public enum UnitState
    {
        Idle,
        Attack,
        ReadySkill,
        Skill
    }

    public class UnitStateComponent:Entity, IAwake
    {
        public UnitState unitState;
    }
}