namespace ET
{
    [Timer(TimerType.AutoSpawnHeroTimer)]
    public class AutoSpawnHeroTimer: ATimer<AutoSpawnHeroComponent>
    {
        public override void Run(AutoSpawnHeroComponent t)
        {
            t.Spawn();
        }
    }

    public class AutoSpwanHeroComponentAwakeSystem: AwakeSystem<AutoSpawnHeroComponent>
    {
        public override void Awake(AutoSpawnHeroComponent self)
        {
            self.time = TimerComponent.Instance.NewRepeatedTimer(3000, TimerType.AutoSpawnHeroTimer, self);
        }
    }

    public class AutoSpwanHeroComponentDestroySystem: DestroySystem<AutoSpawnHeroComponent>
    {
        public override void Destroy(AutoSpawnHeroComponent self)
        {
            TimerComponent.Instance?.Remove(ref self.time);
        }
    }

    public static class AutoSpawnHeroComponentSystem
    {
        public static void Spawn(this AutoSpawnHeroComponent self)
        {
            //Log.Info("随机生成英雄");
            
            TowerDefence towerDefence = self.GetParent<TowerDefence>();

            long Id = towerDefence.playerIds[0];
            Player player = self.DomainScene().GetComponent<PlayerComponent>().Get(Id);
            NumericalComponent numericalComponent = player.GetComponent<NumericalComponent>();
            int energy = numericalComponent.GetAsInt(NumericalType.PlayerEnergy);
            int cost = numericalComponent.GetAsInt(NumericalType.PlayerBuyCount) * 10;
            if (energy < cost)
            {
                //Log.Info("能量不够");
                return;
            }
            self.DomainScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(Id, out towerDefence);
            towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHero(Id);
            numericalComponent.Set(NumericalType.PlayerEnergyBase, energy - cost);
            numericalComponent.Set(NumericalType.PlayerBuyCountBase, (cost / 10)+1);
            towerDefence.GetComponent<HeroSpawnComponent>()?.SpawnRandomHero(towerDefence.playerIds[0]);
        }
    }
}