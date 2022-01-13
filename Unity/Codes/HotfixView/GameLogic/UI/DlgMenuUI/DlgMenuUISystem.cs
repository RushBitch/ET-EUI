using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgMenuUISystem
    {
        public static void RegisterUIEvent(this DlgMenuUI self)
        {
            self.View.EButton_Solo.AddListener(OnSoloButton);
            self.View.EButton_Pvp.AddListener(OnPvpButton);
            self.View.EButton_Team.AddListener(OnTeamButton);
        }

        public static void ShowWindow(this DlgMenuUI self, Entity contextData = null)
        {
        }

        public static void OnSoloButton()
        {
            TowerDefenceComponentFactory.CreateSolo(UIComponent.Instance.DomainScene());
        }

        public static void OnPvpButton()
        {
            TowerDefenceComponentFactory.CreatePvp(UIComponent.Instance.DomainScene());
        }

        public static void OnTeamButton()
        {
            TowerDefenceComponentFactory.CreateTeam(UIComponent.Instance.DomainScene());
        }
    }
}