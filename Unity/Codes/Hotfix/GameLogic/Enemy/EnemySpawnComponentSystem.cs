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
                Unit unit = MyUnityFactory.Create(self.DomainScene(), UnitType.Enemy);
                MoveWithListComponent moveWithListComponent = unit.GetComponent<MoveWithListComponent>();
                if (moveWithListComponent != null)
                {
                    moveWithListComponent.recordMaxMoveDistanceComponent =
                            self.GetParent<TowerDefence>().GetComponent<RecordMaxMoveDistanceComponent>();
                    moveWithListComponent.StartMove(config.pathList, () => { self.DomainScene().GetComponent<UnitComponent>().Remove(unit.Id); });
                }

                unit.AddComponent<TowerDefenceIdComponent, long>(self.Id);
                Game.EventSystem.Publish(new AfterCreateEnemy() { unit = unit });
            }
        }
    }
}