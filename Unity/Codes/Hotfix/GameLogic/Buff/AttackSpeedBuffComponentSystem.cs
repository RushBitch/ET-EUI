namespace ET
{
    public class AttackSpeedBuffComponentAwakeSystem:AwakeSystem<AttackSpeedBuffComponent,int,int>
    {
        public override void Awake(AttackSpeedBuffComponent self, int time, int addition)
        {
            self.addition = addition;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed);
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HeroSpeedBase,speed + addition);
        }
    }
    
    public class AttackSpeedBuffComponentDestroySystem:DestroySystem<AttackSpeedBuffComponent>
    {
        public override void Destroy(AttackSpeedBuffComponent self)
        {
            if (self.Parent.IsDisposed) return;
            int speed = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroSpeed);
            self.Parent.GetComponent<NumericalComponent>().Set(NumericalType.HeroSpeedBase,speed - self.addition);
        }
    }
}