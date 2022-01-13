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
            self.View.EButton_Solo.AddListener(self.OnSoloButton);
            self.View.EButton_Pvp.AddListener(self.OnPvpButton);
            self.View.EButton_Team.AddListener(self.OnTeamButton);
        }

        public static void ShowWindow(this DlgMenuUI self, Entity contextData = null)
        {
        }

        public static void OnSoloButton(this DlgMenuUI self)
        {
            TowerDefenceComponentFactory.CreateSolo(self.DomainScene());
        }

        public static void OnPvpButton(this DlgMenuUI self)
        {
            TowerDefenceComponentFactory.CreatePvp(self.DomainScene());
        }

        public static void OnTeamButton(this DlgMenuUI self)
        {
            TowerDefenceComponentFactory.CreateTeam(self.DomainScene());
        }
    }
}