using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ET
{
    [ObjectSystem]
    public class BattlefieldAwakeSystem: AwakeSystem<Battlefield>
    {
        public override void Awake(Battlefield self)
        {
            self.BattlefieldPlayers.Clear();
        }
    }

    [ObjectSystem]
    public class BattlefieldDestroySystem: DestroySystem<Battlefield>
    {
        public override void Destroy(Battlefield self)
        {
            self.BattlefieldPlayers.Clear();
        }
    }

    public static class BattlefieldSystem
    {
        public static void AddBattlefieldPlayer(this Battlefield self, long id)
        {
            BattlefieldPlayer battlefieldPlayer = self.AddChildWithId<BattlefieldPlayer>(id);
            self.BattlefieldPlayers.Add(battlefieldPlayer);
        }

        public static void SetUp(this Battlefield self)
        {
            EnemySpawnComponent enemySpawnComponent =  self.AddComponent<EnemySpawnComponent>();
            BattlefieldMapComponent battlefieldMapComponent = self.GetComponent<BattlefieldMapComponent>();
            List<Vector3> spawnPoints = battlefieldMapComponent.GetSpawnPoints();
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                EnemySpawnPoint enemySpawnPoint = enemySpawnComponent.AddChild<EnemySpawnPoint,Vector3>(spawnPoints[i]);
                enemySpawnComponent.Add(enemySpawnPoint);
            }
        }
    }
}