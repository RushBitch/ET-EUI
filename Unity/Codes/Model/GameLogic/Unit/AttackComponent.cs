using UnityEngine;

namespace ET
{
    public class AttackComponent:Entity, IUpdate, IAwake
    {
        public int damage;
        public float speed;
        public Unit enemy;

        public bool startAttack = false;

        //public ChangeWeaponPosition changeWeaponPosition;
    }
}