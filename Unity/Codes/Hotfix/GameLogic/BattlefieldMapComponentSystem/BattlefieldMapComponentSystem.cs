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
        }
    }

    public static class BattlefieldComponentSystem
    {
        public static void Awake(this BattlefieldMapComponent self, int[][] battlefieldMap)
        {
            self.battlefieldMap = battlefieldMap;
            self.IndexPositonDictionary = new Dictionary<int, Vector3>();
            for (int i = 0; i < self.battlefieldMap.Length; i++)
            {
                for (int j = 0; j < self.battlefieldMap[i].Length; j++)
                {
                    float x = j - 3f;
                    float z = i - 5f;
                    self.IndexPositonDictionary.Add(i * self.battlefieldMap[i].Length + j, new Vector3(x, 0, z));
                }
            }
        }
    }
}