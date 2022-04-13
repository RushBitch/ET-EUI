using ET.EventType;
using UnityEngine;

namespace ET
{
    public class WeaponComponentAwakeSystem: AwakeSystem<WeaponComponent>
    {
        public override void Awake(WeaponComponent self)
        {
            self.Awake();
        }
    }

    public class WeaponComponentUpdateSystem: UpdateSystem<WeaponComponent>
    {
        public override void Update(WeaponComponent self)
        {
            self.Update();
        }
    }

    public class WeaponComponentDestorySystem: DestroySystem<WeaponComponent>
    {
        public override void Destroy(WeaponComponent self)
        {
            Game.EventSystem.Publish(new AfterDestroyWeapon() { unit = (Unit) self.Parent });
        }
    }

    public static class WeaponComponentSystem
    {
        public static void Awake(this WeaponComponent self)
        {
            self.startAttack = false;
        }

        public static void Update(this WeaponComponent self)
        {
            if (!self.startAttack)
                return;
            if (self.enemy == null)
            {
                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
                return;
            }
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
                bool isDead = self.enemy.GetComponent<LifeComponent>().Attacked(self.damage);
                if (isDead)
                {
                    Game.EventSystem.Publish(new EnemyKilledByHero() { id = self.towerDefenceId});
                }
                
                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            }
        }

        public static void StartAttack(this WeaponComponent self)
        {
            self.startAttack = true;
        }

        public static void SetPosition(this WeaponComponent self, Vector3 position)
        {
            self.GetParent<Unit>().Position = position;
        }
    }
}