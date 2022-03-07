using UnityEngine;

namespace ET
{
    public class WeaponComponent:Entity, IUpdate, IAwake, IDestroy
    {
        public int damage;
        public float speed;
        public Unit enemy;
        public Unit hero;
        public bool startAttack = false;

        //public ChangeWeaponPosition changeWeaponPosition;
    }
}