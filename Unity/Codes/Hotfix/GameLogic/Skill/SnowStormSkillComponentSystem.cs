namespace ET
{
    public static class SnowStormSkillComponentSystem
    {
        public static async void Start(this SnowStormSkillComponent self)
        {
            if (self.DomainScene().GetComponent<UnitComponent>() == null) return;
            for (int i = 0; i < 5; i++)
            {
                foreach (var unit in self.DomainScene().GetComponent<UnitComponent>().Children.Values)
                {
                    if (unit.GetComponent<MoveWithListComponent>() == null)
                    {
                        continue;
                    }

                    if (unit.GetComponent<TowerDefenceIdComponent>().ID != self.defenceID)
                    {
                        continue;
                    }

                    if (unit.GetComponent<EnemySpeedBuffComponent>() == null)
                    {
                        unit.AddComponent<EnemySpeedBuffComponent, int, long>(-10, TimeHelper.ServerNow() + self.showtime + 100);
                    }
                    else
                    {
                        unit.GetComponent<EnemySpeedBuffComponent>().Refresh(TimeHelper.ServerNow() + self.showtime + 100);
                    }
                }

                await TimerComponent.Instance.WaitAsync(self.showtime / 5);
            }

            self.DomainScene().GetComponent<UnitComponent>().Remove(self.Id);
        }
    }
}