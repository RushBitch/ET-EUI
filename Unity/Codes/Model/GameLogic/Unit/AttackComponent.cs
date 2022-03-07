using UnityEngine;

namespace ET
{
    public class AttackComponent: Entity, IAwake
    {
        public bool stop;
        public Unit attackEnemy;
        public bool canExeuteSkill;
        public Vector3 skillPosition;
    }
}