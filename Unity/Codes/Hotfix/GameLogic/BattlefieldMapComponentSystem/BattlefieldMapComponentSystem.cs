using System;
using System.Collections.Generic;
using System.Numerics;

namespace ET
{
    [ObjectSystem]
    public class BattlefieldMapComponentAwakeSystem: AwakeSystem<BattlefieldMapComponent, int[][]>
    {
        public override void Awake(BattlefieldMapComponent self, int[][] battlefieldMap)
        {
            self.Awake(battlefieldMap);
        }
    }

    [ObjectSystem]
    public class BattlefieldMapComponentDestroySystem: DestroySystem<BattlefieldMapComponent>
    {
        public override void Destroy(BattlefieldMapComponent self)
        {
            self.battlefieldMap = null;
            self.IndexPositonDictionary.Clear();
            self.spawnPoints.Clear();
            self.endPoinit = Vector3.Zero;
        }
    }

    public static class BattlefieldComponentSystem
    {
        public static void Awake(this BattlefieldMapComponent self, int[][] battlefieldMap)
        {
            self.battlefieldMap = battlefieldMap;
            self.IndexPositonDictionary = new Dictionary<int, Vector3>();
            self.spawnPoints = new List<Vector3>();
            self.endPoinit = new Vector3();
            for (int i = 0; i < self.battlefieldMap.Length; i++)
            {
                for (int j = 0; j < self.battlefieldMap[i].Length; j++)
                {
                    Vector3 points = new Vector3(j - 3f, 0, i - 5f);
                    self.IndexPositonDictionary.Add(i * self.battlefieldMap[i].Length + j, points);
                    if (self.battlefieldMap[i][j] == 3)
                    {
                        self.spawnPoints.Add(points);
                    }

                    if (self.battlefieldMap[i][j] == 3)
                    {
                        self.endPoinit = points;
                    }
                }
            }
        }

        public static List<Vector3> GetSpawnPoints(this BattlefieldMapComponent self)
        {
            return self.spawnPoints;
        }

        public static Vector3 GetDestinationPoints(this BattlefieldMapComponent self)
        {
            return self.endPoinit;
        }
    }
}