using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET
{
    public static class DlgTowerDefenceUISystem
    {
        public static void RegisterUIEvent(this DlgTowerDefenceUI self)
        {
            self.View.EButton_BackToMainButton.AddListener(self.OnBackToMainButton);
            self.View.EButton_CreateHeroButton.AddListener(self.OnCreateHero);
            self.View.EButton_CreateHero_PvpButton.AddListener(self.OnCreateHeroPvp);
            self.View.ES_TopInfo.EButton_InfoSwitchButton.AddListener(self.OnSwitchButton);
        }

        public static void ShowWindow(this DlgTowerDefenceUI self, Entity contextData = null)
        {
            HeroCompoundComponent heroCompoundComponent =
                    self.DomainScene().GetComponent<TowerDefenceCompoment>().GetComponent<HeroCompoundComponent>();
            TouchEventComponent eventComponent = self.View.EGSprite_HeroComboundRectTransform.gameObject.GetComponent<TouchEventComponent>();
            eventComponent.BeginDragHandler = data => heroCompoundComponent.onTouchStart(data);
            eventComponent.DragHandler = data => heroCompoundComponent.onTouchMove(data);
            eventComponent.EndDragHandler = data => heroCompoundComponent.onTouchEnd(data);
            foreach (var VARIABLE in self.DomainScene().GetComponent<PlayerComponent>().Children.Values)
            {
                VARIABLE.GetComponent<NumericalComponent>().Set(NumericalType.PlayerEnergyBase, 100);
                VARIABLE.GetComponent<NumericalComponent>().Set(NumericalType.PlayerBuyCountBase, 1);
            }

            foreach (var VARIABLE in self.DomainScene().GetComponent<TowerDefenceCompoment>().Children.Values)
            {
                NumericalComponent numericalComponent = VARIABLE.AddComponent<NumericalComponent>();
                numericalComponent.Set(NumericalType.TowerDefenceHpBase, 3);
            }

            for (int i = 0; i < self.View.ES_ButtomInfo.EG_MyHpRectTransform.childCount; i++)
            {
                self.View.ES_ButtomInfo.EG_MyHpRectTransform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < self.View.ES_TopInfo.EG_EnemyMyHpRectTransform.childCount; i++)
            {
                self.View.ES_TopInfo.EG_EnemyMyHpRectTransform.GetChild(i).gameObject.SetActive(true);
            }
        }

        private static void OnBackToMainButton(this DlgTowerDefenceUI self)
        {
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_TowerDefenceUI);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MenuUI);

            TowerDefenceCompoment towerDefenceComponent = self.DomainScene().GetComponent<TowerDefenceCompoment>();
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            if (towerDefenceComponent != null)
            {
                List<long> ids = new List<long>();
                foreach (var unit in unitComponent.Children.Values)
                {
                    ids.Add(unit.Id);
                }

                foreach (var id in ids)
                {
                    unitComponent.Remove(id);
                }

                towerDefenceComponent.Dispose();
            }

            PlayerComponent playerComponent = self.DomainScene().GetComponent<PlayerComponent>();
            List<Player> players = new List<Player>();
            foreach (var VARIABLE in playerComponent.Children.Values)
            {
                players.Add((Player) VARIABLE);
            }

            foreach (var VARIABLE in players)
            {
                VARIABLE?.Dispose();
            }

            List<GameObject> gameObjects = new List<GameObject>();
            for (int i = 0; i < self.View.ES_BattleInfo.EG_MyEnemyCountRectTransform.childCount; i++)
            {
                gameObjects.Add(self.View.ES_BattleInfo.EG_MyEnemyCountRectTransform.GetChild(i).gameObject);
            }

            for (int i = 0; i < self.View.ES_BattleInfo.EG_EnemyEnemyCountRectTransform.childCount; i++)
            {
                gameObjects.Add(self.View.ES_BattleInfo.EG_EnemyEnemyCountRectTransform.GetChild(i).gameObject);
            }

            foreach (var gameObject in gameObjects)
            {
                UnityEngine.Object.Destroy(gameObject);
            }

            BgmComponent.Instance.Stop();
        }

        private static void OnCreateHero(this DlgTowerDefenceUI self)
        {
            long Id = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            Player player = self.DomainScene().GetComponent<PlayerComponent>().Get(Id);
            NumericalComponent numericalComponent = player.GetComponent<NumericalComponent>();
            int energy = numericalComponent.GetAsInt(NumericalType.PlayerEnergy);
            int cost = numericalComponent.GetAsInt(NumericalType.PlayerBuyCount) * 10;
            if (energy < cost)
            {
                Log.Info("能量不够");
                self.ShowEnergyTip();
                return;
            }

            TowerDefence towerDefence;
            self.DomainScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(Id, out towerDefence);
            towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHero(Id);
            numericalComponent.Set(NumericalType.PlayerEnergyBase, energy - cost);
            numericalComponent.Set(NumericalType.PlayerBuyCountBase, (cost / 10) + 1);
        }

        private static void OnCreateHeroPvp(this DlgTowerDefenceUI self)
        {
            foreach (var towerDefence in self.DomainScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.Values)
            {
                foreach (var id in towerDefence.playerIds)
                {
                    if (id != self.DomainScene().GetComponent<PlayerComponent>().MyId)
                    {
                        towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHero(id);
                    }
                }
            }
        }

        public static void AddMyEnemyCount(this DlgTowerDefenceUI self)
        {
            Transform transform = self.View.ES_BattleInfo.EG_MyEnemyCountRectTransform;
            ResourcesComponent.Instance.LoadBundle("ui.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("ui.unity3d", "EnemyCount");
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle, transform);
            gameObject.transform.localScale = Vector3.one;
        }

        public static void AddEnemyEnemyCount(this DlgTowerDefenceUI self)
        {
            Transform transform = self.View.ES_BattleInfo.EG_EnemyEnemyCountRectTransform;
            ResourcesComponent.Instance.LoadBundle("ui.unity3d");
            GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("ui.unity3d", "EnemyCount");
            GameObject gameObject = UnityEngine.Object.Instantiate(bundle, transform);
            gameObject.transform.localScale = Vector3.one;
        }

        public static void RemoveMyEnemyCount(this DlgTowerDefenceUI self)
        {
            Transform transform = self.View.ES_BattleInfo.EG_MyEnemyCountRectTransform;
            Transform child = transform.GetChild(transform.childCount - 1);
            if (child != null)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }

        public static void RemoveEnemyEnemyCount(this DlgTowerDefenceUI self)
        {
            Transform transform = self.View.ES_BattleInfo.EG_EnemyEnemyCountRectTransform;
            Transform child = transform.GetChild(transform.childCount - 1);
            if (child != null)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }

        public static void OnSwitchButton(this DlgTowerDefenceUI self)
        {
            if (self.switchState)
            {
                self.switchState = false;
                self.View.ES_TopInfo.uiTransform.DOLocalMoveY(self.View.ES_TopInfo.uiTransform.localPosition.y + 170, 0.5f);
                self.DomainScene().GetComponent<TowerDefenceCompoment>().GetComponent<TowerDefenceCameraComponent>().SwitchToNear();
                self.View.ES_TopInfo.EButton_InfoSwitchButton.transform.Rotate(new Vector3(0, 0, 1), 180f);
            }
            else
            {
                self.switchState = true;
                self.View.ES_TopInfo.uiTransform.DOLocalMoveY(self.View.ES_TopInfo.uiTransform.localPosition.y - 170, 0.5f);
                self.DomainScene().GetComponent<TowerDefenceCompoment>().GetComponent<TowerDefenceCameraComponent>().SwitchToFar();
                self.View.ES_TopInfo.EButton_InfoSwitchButton.transform.Rotate(new Vector3(0, 0, 1), -180f);
            }
        }

        public static void ShowEnergyTip(this DlgTowerDefenceUI self)
        {
            self.View.E_TextTipText.gameObject.SetActive(true);
            self.View.E_TextTipText.rectTransform.anchoredPosition3D = new Vector3(0, -555);
            self.Sequence = DOTween.Sequence();
            self.Sequence.Append(self.View.E_TextTipText.rectTransform.DOLocalMoveY(-500, 0.5f));
            self.Sequence.AppendCallback(() => { self.View.E_TextTipText.gameObject.SetActive(false); });
        }
    }
}