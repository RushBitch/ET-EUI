using ET.EventType;

namespace ET
{
    [Timer(TimerType.EnemyDeadTimer)]
    public class EnemyDead: ATimer<LifeComponent>
    {
        public override void Run(LifeComponent self)
        {
            self.DomainScene().GetComponent<UnitComponent>()?.Remove(self.Id);
        }
    }

    public static class LifeComponentSystem
    {
        public static bool Attacked(this LifeComponent self, int Damage)
        {
            if (self.dead) return false;
            NumericalComponent numericalComponent = self.Parent.GetComponent<NumericalComponent>();
            //Log.Info($"敌人{self.Parent.Id}受到伤害{Damage},剩余HP为{numericalComponent.GetAsInt(NumericalType.Hp) - Damage}");
            var hp = numericalComponent.GetAsInt(NumericalType.HpBase);
            hp -= Damage;
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HpBase, hp);
            Game.EventSystem.Publish(new UnitAttacked() { unit = self.GetParent<Unit>(), damage = Damage });
            if (hp <= 0)
            {
                //Log.Info($"敌人死亡");
                self.dead = true;
                //Game.EventSystem.Publish(new CleanMaxMoveDistance() { unit = self.GetParent<Unit>() });
                Game.EventSystem.Publish(new AfterEnemyDead() { unit = self.GetParent<Unit>() });
                if (self.Parent.GetComponent<ReverseSpwanComponent>() != null)
                {
                    Game.EventSystem.Publish(new SpawnReverseEnemy() { unit = self.GetParent<Unit>() });
                }

                if (self.GetParent<Unit>().Config.Type == (int) UnitType.Boss)
                {
                    TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 1500, TimerType.EnemyDeadTimer, self);
                }
                else
                {
                    TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 100, TimerType.EnemyDeadTimer, self);
                }

                return true;
            }

            return false;
        }

        public static void PreAttacked(this LifeComponent self, int Damage)
        {
            if (self.IsDisposed || self.Parent.IsDisposed) return;
            NumericalComponent numericalComponent = self.Parent.GetComponent<NumericalComponent>();
            var hp = numericalComponent.GetAsInt(NumericalType.PreHpBase);
            hp -= Damage;
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.PreHpBase, hp);
            //Log.Info($"敌人受到预伤害{Damage},剩余HP为{self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.PreHp)}");
            if (hp <= 0)
            {
                //Log.Info($"敌人预死亡");
                self.preDead = true;
                Game.EventSystem.Publish(new CleanMaxMoveDistance() { unit = self.GetParent<Unit>() });
            }
        }
    }
}