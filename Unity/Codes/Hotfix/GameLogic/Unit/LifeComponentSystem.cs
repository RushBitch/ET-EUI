using ET.EventType;

namespace ET
{
    public static class LifeComponentSystem
    {
        public static void Attacked(this LifeComponent self, int Damage)
        {
            NumericalComponent numericalComponent = self.Parent.GetComponent<NumericalComponent>();
            //Log.Info($"敌人受到伤害{Damage},剩余HP为{numericalComponent.GetAsInt(NumericalType.Hp) - Damage}");
            var hp = numericalComponent.GetAsInt(NumericalType.HpBase);
            hp -= Damage;
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HpBase, hp);
            Game.EventSystem.Publish(new UnitAttacked() { unit = self.GetParent<Unit>(), damage = Damage });
            if (hp <= 0)
            {
                //Log.Info($"敌人死亡");
                self.dead = true;
                self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
            }
        }

        public static void PreAttacked(this LifeComponent self, int Damage)
        {
            NumericalComponent numericalComponent = self.Parent.GetComponent<NumericalComponent>();
            var hp = numericalComponent.GetAsInt(NumericalType.PreHpBase);
            hp -= Damage;
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.PreHpBase, hp);
            //Log.Info($"敌人受到预伤害{Damage},剩余HP为{self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.PreHp)}");
            if (hp <= 0)
            {
                //Log.Info($"敌人预死亡");
                self.preDead = true;
                Game.EventSystem.Publish(new CleanMaxMoveDistance(){unit = self.GetParent<Unit>()});
            }
        }
    }
}