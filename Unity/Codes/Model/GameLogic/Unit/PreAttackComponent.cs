using System.Collections.Generic;

namespace ET
{
    public class PreAttackComponent:Entity,IAwake, IDestroy
    {
        public List<Unit> enemys = new List<Unit>();
        public int damage;
    }
}