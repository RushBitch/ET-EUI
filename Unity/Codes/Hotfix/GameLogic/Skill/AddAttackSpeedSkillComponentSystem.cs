using ET.EventType;

namespace ET
{
    public static class AddAttackSpeedSkillComponentSystem
    {
        public static async void Add(this AddAttackSpeedSkillComponent self)
        {
            int skillShowTime = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.SkillShowTime);
            if (self.Parent.GetComponent<AttackSpeedBuffComponent>() != null) return;
            self.Parent.AddComponent<AttackSpeedBuffComponent, int, int>(skillShowTime, 40);
            Game.EventSystem.Publish(new PlayerEffect()
            {
                pos = TransformConvert.ConvertPositon(self.GetParent<Unit>(), self.GetParent<Unit>().Position),
                effectId = 1306,
                effectTime = skillShowTime
            });
            await TimerComponent.Instance.WaitAsync(skillShowTime);
            if (self.Parent == null || self.Parent.IsDisposed)
            {
                return;
            }
            self.Parent.RemoveComponent<AttackSpeedBuffComponent>();
        }
    }
}