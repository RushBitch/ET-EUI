namespace ET
{
    public enum WeaponState
    {
        Null,
        Ready,
        Attack,
        Rest,
    }
    
    public class WeaponComponent: Entity, IAwake, IUpdate
    {
        public float targetTime;
        public float currentTiem;

        public WeaponState state;

        public bool stop;

        public Unit attackEnemy;
    }
}