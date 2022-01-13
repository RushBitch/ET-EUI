using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace ET
{
    [ObjectSystem]
    public class BattlefieldMapViewComponentAwakeSystem: AwakeSystem<BattlefieldMapViewComponent, Transform>
    {
        public override void Awake(BattlefieldMapViewComponent self, Transform parent)
        {
            self.Awake(parent);
        }
    }
    
    [ObjectSystem]
    public class BattlefieldMapViewComponentDestroySystem: DestroySystem<BattlefieldMapViewComponent>
    {
        public override void Destroy(BattlefieldMapViewComponent self)
        {
            foreach (var VARIABLE in self.indexGameObjects.Values)
            {
                GameObject.Destroy(VARIABLE); 
            }
        }
    }

    public static class BattlefieldMapViewComponentSystem
    {
        public static void Awake(this BattlefieldMapViewComponent self, Transform parent)
        {
            self.mapGridParent = parent;
            self.indexGameObjects = new Dictionary<int, GameObject>();
            BattlefieldMapComponent battlefieldMapComponent = (BattlefieldMapComponent)self.Parent;
            int[][] battlefieldMap = battlefieldMapComponent.battlefieldMap;
            for (int i = 0; i < battlefieldMap.Length; i++)
            {
                for (int j = 0; j < battlefieldMap[i].Length; j++)
                {
                    int mapGridType = battlefieldMap[i][j];
                    GameObject gameObject = InstantiateMapGrid(mapGridType, self.mapGridParent);
                    Vector3 pos;
                    int index = i * battlefieldMap[i].Length + j;
                    battlefieldMapComponent.IndexPositonDictionary.TryGetValue(i*battlefieldMap[i].Length + j, out pos);
                    gameObject.transform.localPosition = new UnityEngine.Vector3(pos.X, pos.Y, pos.Z);
                    self.indexGameObjects.Add(index,gameObject);
                }
            }
        }

        private static GameObject InstantiateMapGrid(int mapGridType, Transform parent)
        {
            switch (mapGridType)
            {
                case 0:
                    return (GameObject) UnityEngine.Object.Instantiate(ResourcesComponent.Instance.GetAsset("MapGrid.unity3d", "MapGridEmpty"),
                        parent);
                case 1:
                    return (GameObject) UnityEngine.Object.Instantiate(ResourcesComponent.Instance.GetAsset("MapGrid.unity3d", "MapGridTower"),
                        parent);
                case 2:
                    return (GameObject) UnityEngine.Object.Instantiate(ResourcesComponent.Instance.GetAsset("MapGrid.unity3d", "MapGridAttacker"),
                        parent);
                case 3:
                    return (GameObject) UnityEngine.Object.Instantiate(ResourcesComponent.Instance.GetAsset("MapGrid.unity3d", "MapGridEntry"),
                        parent);
                case 4:
                    return (GameObject) UnityEngine.Object.Instantiate(ResourcesComponent.Instance.GetAsset("MapGrid.unity3d", "MapGridExit"),
                        parent);
                default:
                    return null;
            }
        }
    }
}