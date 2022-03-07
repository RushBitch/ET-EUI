using System;
using System.Collections.Generic;
using ET.EventType;

namespace ET
{
    public class EnemySpawnComponentAwakeSystem: AwakeSystem<EnemySpawnComponent>
    {
        public override void Awake(EnemySpawnComponent self)
        {
            self.pathConfigs = new List<BattlefieldEnemyPathConfig>();
        }
    }

    public class EnemySpawnComponentDestorySystem: DestroySystem<EnemySpawnComponent>
    {
        public override void Destroy(EnemySpawnComponent self)
        {
            TimerComponent.Instance?.Remove(ref self.spwanTimer);
        }
    }

    [Timer(TimerType.EnemySpawnTimer)]
    public class SpawnEnemyTimer: ATimer<EnemySpawnComponent>
    {
        public override void Run(EnemySpawnComponent self)
        {
            try
            {
                self.SpawnEnemy();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    public static class EnemySpawnComponentSystem
    {
        public static void AddPath(this EnemySpawnComponent self, BattlefieldEnemyPathConfig config)
        {
            self.pathConfigs.Add(config);
        }

        public static void StartSpawnEnemy(this EnemySpawnComponent self)
        {
            self.spwanTimer = TimerComponent.Instance.NewRepeatedTimer(1300, TimerType.EnemySpawnTimer, self);
            //self.SpawnEnemy();
        }

        public static void StopSpawnEnemy(this EnemySpawnComponent self)
        {
            TimerComponent.Instance.Remove(ref self.spwanTimer);
        }

        public static void SpawnEnemy(this EnemySpawnComponent self)
        {
            foreach (var config in self.pathConfigs)
            {
                //int configId = 1000 + RandomHelper.RandomNumber(1, 3);
                Log.Info("创建英雄");
                Unit unit = EnemyFactory.Create(self.DomainScene(), 1002, self.Id);
                unit.GetComponent<MoveWithListComponent>()
                        .StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
            }
        }

        public static void SpawnBoss(this EnemySpawnComponent self)
        {
            foreach (var config in self.pathConfigs)
            {
                Unit unit = EnemyFactory.Create(self.DomainScene(), 1001, self.Id);
                unit.GetComponent<MoveWithListComponent>()
                        .StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
            }
        }
    }
}