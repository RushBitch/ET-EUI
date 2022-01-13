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
            UIComponent.Instance.HideWindow(WindowID.WindowID_TowerDefenceUI);
            UIComponent.Instance.ShowWindow(WindowID.WindowID_MenuUI);
            if (self.towerDefenceComponent != null)
            {
                self.towerDefenceComponent.Dispose();
            }
        }
    }
}