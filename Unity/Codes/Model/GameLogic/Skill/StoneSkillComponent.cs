namespace ET
{
    public class StoneSkillComponent:Entity, IAwake, IDestroy
    {
        public long heroId;
        public float attackRange;
        public int damage;
        public int attackTime;
        public long skillTimer;
    }
}