using UnityEngine;

namespace ET
{
    public class AttackComponentAwakeSystem: AwakeSystem<AttackComponent>
    {
        public override void Awake(AttackComponent self)
        {
            self.Awake();
        }
    }

    public class AttackComponentUpdateSystem: UpdateSystem<AttackComponent>
    {
        public override void Update(AttackComponent self)
        {
            self.Update();
        }
    }

    public static class AttackComponentSystem
    {
        public static void Awake(this AttackComponent self)
        {
            self.startAttack = false;
            //self.changeWeaponPosition = new ChangeWeaponPosition() { weapon = self };
        }

        public static void Update(this AttackComponent self)
        {
            if (!self.startAttack)
                return;
            if (self.enemy.IsDisposed)
            {
                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
                return;
            }

            float delta = MyTimeHelper.GetDeltaTime();
            Vector3 dir = self.enemy.Position - self.GetParent<Unit>().Position;
            self.SetPosition(self.GetParent<Unit>().Position + dir.normalized * delta * self.speed);
            if (dir.magnitude < 0.2)
            {
                self.enemy.GetComponent<LifeComponent>().Attacked(self.damage);
                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            }
        }

        public static void StartAttack(this AttackComponent self)
        {
            self.startAttack = true;
        }

        public static void SetPosition(this AttackComponent self, Vector3 position)
        {
            self.GetParent<Unit>().Position = position;
        }
    }
}