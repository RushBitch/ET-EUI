using System.Collections.Generic;

namespace ET
{
    public class TowerDefenceComponentAwakeSystem: AwakeSystem<TowerDefenceCompoment>
    {
        public override void Awake(TowerDefenceCompoment self)
        {
            self.playerIdTowerDefences = new Dictionary<long, TowerDefence>();
            CountDownComponent countDownComponent = self.AddComponent<CountDownComponent>();
            self.bossDeadCount = 0;
            self.round = 0;
        }
    }

    public static class TowerDefenceComponentSystem
    {
        public static void Start(this TowerDefenceCompoment self, TowerDefenceMode mode)
        {
            self.towerDefenceMode = mode;
            self.playerIdTowerDefences.Clear();
        }

        public static void Clear(this TowerDefenceCompoment self)
        {
            self.towerDefenceMode = TowerDefenceMode.Null;
            foreach (var towerDefence in self.playerIdTowerDefences.Values)
            {
                towerDefence.Dispose();
            }

            self.playerIdTowerDefences.Clear();
        }

        public static void Add(this TowerDefenceCompoment self, long id, TowerDefence towerDefence)
        {
            self.playerIdTowerDefences.Add(id, towerDefence);
        }
    }
}