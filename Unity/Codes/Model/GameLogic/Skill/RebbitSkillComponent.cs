using UnityEngine;

namespace ET
{
    public class RebbitSkillComponent: Entity, IAwake, IDestroy, IUpdate
    {
        public int damage;
        public float speed;
        public Vector3 enemyPosition;
        public Unit hero;
        public bool startAttack = false;
        public long towerDefenceId;
        public float attackRange;
    }
}