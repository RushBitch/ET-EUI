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
        }

        public static void ShowWindow(this DlgTowerDefenceUI self, Entity contextData = null)
        {
            self.towerDefenceComponent = (TowerDefenceComponent) contextData;
        }

        private static void OnBackToMainButton(this DlgTowerDefenceUI self)
        {
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_TowerDefenceUI);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_MenuUI);
            if (self.towerDefenceComponent != null)
            {
                self.towerDefenceComponent.Dispose();
            }
        }
    }
}