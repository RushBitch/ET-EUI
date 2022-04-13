namespace ET
{
    public class PreAttackComponent:Entity,IAwake, IDestroy
    {
        public Unit enemy;
        public int damage;
    }
}