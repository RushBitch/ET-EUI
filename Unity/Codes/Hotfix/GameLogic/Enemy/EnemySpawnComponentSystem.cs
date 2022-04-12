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
            self.spwanTimer = TimerComponent.Instance.NewRepeatedTimer(1000, TimerType.EnemySpawnTimer, self);
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
                //Log.Info("创建英雄");
                self.spawnCount += 1;
                int configId = 0;
                if (self.spawnCount % 5 == 0)
                {
                    configId = 1004;
                }

                if (self.spawnCount % 10 == 0)
                {
                    configId = 1005;
                }

                if (self.spawnCount % 5 != 0 && self.spawnCount % 10 != 0)
                {
                    configId = 1003;
                }

                Unit unit = EnemyFactory.Create(self.DomainScene(), configId, self.Id, true);
                if (unit == null) return;
                unit.GetComponent<MoveWithListComponent>()
                        .StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
            }
        }

        public static void SpawnEnemy(this EnemySpawnComponent self, int configId)
        {
            foreach (var config in self.pathConfigs)
            {
                Unit unit = EnemyFactory.Create(self.DomainScene(), configId, self.Id);
                if (unit == null) return;
                unit.GetComponent<MoveWithListComponent>()
                        .StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
            }
        }

        public static void SpawnBoss(this EnemySpawnComponent self)
        {
            foreach (var config in self.pathConfigs)
            {
                Unit unit = EnemyFactory.Create(self.DomainScene(), 1001, self.Id);
                if (unit == null) return;
                unit.GetComponent<MoveWithListComponent>()
                        .StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
            }
        }
    }
}