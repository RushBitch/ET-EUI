namespace ET
{
    public class AttackDamageBuffComponentAwakeSystem: AwakeSystem<AttackDamageBuffComponent, int, int>
    {
        public override void Awake(AttackDamageBuffComponent self, int time, int addition)
        {
            self.addition = addition;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HeroDamageBase, speed + addition);
        }
    }

    public class AttackDamageBuffComponentDestroySystem: DestroySystem<AttackDamageBuffComponent>
    {
        public override void Destroy(AttackDamageBuffComponent self)
        {
            if (self.Parent.IsDisposed) return;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HeroDamageBase, speed - self.addition);
        }
    }
}