using System;
using UnityEngine;

namespace ET
{
    public static class TowerDefenceComponentViewFactory
    {
        public static async ETTask Create(TowerDefenceComponent towerDefence)
        {
            switch (towerDefence.towerDefenceType)
            {
                case TowerDefenceType.Solo:
                    await CreateSolo(towerDefence);
                    break;
                case TowerDefenceType.Pvp:
                    await CreatePvp(towerDefence);
                    break;
                case TowerDefenceType.Team:
                    await CreateTeam(towerDefence);
                    break;
                default:
                    break;
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask CreateSolo(TowerDefenceComponent towerDefence)
        {
            //加载地图
            TowerDefenceComponentView towerDefenceView = towerDefence.AddComponent<TowerDefenceComponentView>();
            Battlefield battlefield = towerDefence.GetChild<Battlefield>(towerDefence.battlefieldIds[0]);
            if (battlefield != null)
            {
                BattlefieldView battlefieldView = battlefield.AddComponent<BattlefieldView, GameObject>(towerDefenceView.towerDefenceRoot);

                //地图配置
                BattlefieldMapComponent battlefieldMapComponent = battlefield.GetComponent<BattlefieldMapComponent>();
                if (battlefieldMapComponent != null)
                {
                    await ResourcesComponent.Instance.LoadBundleAsync("MapGrid.Unity3d");
                    battlefieldMapComponent.AddComponent<BattlefieldMapViewComponent, Transform>(battlefieldView.BattleRoot.transform);
                }

                //显示地图敌人出生点
                if (battlefield.GetComponent<EnemySpawnComponent>() != null)
                {

                    battlefield.GetComponent<EnemySpawnComponent>().AddComponent<EnemySpawnViewComponent, Transform>(battlefieldView.BattleRoot.transform);
                }
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask CreatePvp(TowerDefenceComponent towerDefence)
        {
            //加载地图
            TowerDefenceComponentView towerDefenceView = towerDefence.AddComponent<TowerDefenceComponentView>();
            for (int i = 0; i < towerDefence.battlefieldIds.Length; i++)
            {
                Battlefield battlefield = towerDefence.GetChild<Battlefield>(towerDefence.battlefieldIds[i]);
                if (battlefield != null)
                {
                    BattlefieldView battlefieldView = battlefield.AddComponent<BattlefieldView, GameObject>(towerDefenceView.towerDefenceRoot);
                    var pos = battlefieldView.BattleRoot.transform.position;
                    if (i == 0)
                    {
                        battlefieldView.BattleRoot.transform.position = new Vector3(pos.x, pos.y, pos.z - 3f);
                    }
                    else
                    {
                        battlefieldView.BattleRoot.transform.position = new Vector3(pos.x, pos.y, pos.z + 3f);
                        battlefieldView.BattleRoot.transform.localScale = new Vector3(1, 1, -1);
                    }

                    BattlefieldMapComponent battlefieldMapComponent = battlefield.GetComponent<BattlefieldMapComponent>();
                    if (battlefieldMapComponent != null)
                    {
                        await ResourcesComponent.Instance.LoadBundleAsync("MapGrid.Unity3d");
                        battlefieldMapComponent.AddComponent<BattlefieldMapViewComponent, Transform>(battlefieldView.BattleRoot.transform);
                    }
                }
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask CreateTeam(TowerDefenceComponent towerDefence)
        {
            //加载地图
            TowerDefenceComponentView towerDefenceView = towerDefence.AddComponent<TowerDefenceComponentView>();
            Battlefield battlefield = towerDefence.GetChild<Battlefield>(towerDefence.battlefieldIds[0]);
            if (battlefield != null)
            {
                BattlefieldView battlefieldView = battlefield.AddComponent<BattlefieldView, GameObject>(towerDefenceView.towerDefenceRoot);

                BattlefieldMapComponent battlefieldMapComponent = battlefield.GetComponent<BattlefieldMapComponent>();
                if (battlefieldMapComponent != null)
                {
                    await ResourcesComponent.Instance.LoadBundleAsync("MapGrid.Unity3d");
                    battlefieldMapComponent.AddComponent<BattlefieldMapViewComponent, Transform>(battlefieldView.BattleRoot.transform);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}