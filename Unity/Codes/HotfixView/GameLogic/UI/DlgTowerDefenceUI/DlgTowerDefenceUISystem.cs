using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgTowerDefenceUISystem
    {
        public static void RegisterUIEvent(this DlgTowerDefenceUI self)
        {
            self.View.EButton_BackToMain.AddListener(self.OnBackToMainButton);
            self.View.EButton_CreateHero.AddListener(self.OnCreateHero);
            self.View.EButton_CreateHero_Pvp.AddListener(self.OnCreateHeroPvp);
        }

        public static void ShowWindow(this DlgTowerDefenceUI self, Entity contextData = null)
        {
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
        }

        private static void OnCreateHero(this DlgTowerDefenceUI self)
        {
            long Id = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            TowerDefence towerDefence;
            self.DomainScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.TryGetValue(Id, out towerDefence);
            towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHero(Id);
        }

        private static void OnCreateHeroPvp(this DlgTowerDefenceUI self)
        {
            foreach (var towerDefence in self.DomainScene().GetComponent<TowerDefenceCompoment>().playerIdTowerDefences.Values)
            {
                //Log.Info(towerDefence.ToString());
                foreach (var id in towerDefence.playerIds)
                {
                    if (id != self.DomainScene().GetComponent<PlayerComponent>().MyId)
                    {
                        //Log.Info(towerDefence.GetComponent<HeroSpawnComponent>().ToString());
                        towerDefence.GetComponent<HeroSpawnComponent>().SpawnRandomHero(id);
                    }
                }
            }
        }
    }
}