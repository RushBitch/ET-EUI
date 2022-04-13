namespace ET
{
    public class FireSkillComponent: Entity, IDestroy, IAwake
    {
        public long heroId;
        public float attackRange;
        public int damage;
        public int deltaTime;
        public int attackTime;
        public long skillTimer;
        public long towerDefenceID;
    }
}