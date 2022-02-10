using System.Collections;
using System.Collections.Generic;
using System;
using ET.EventType;
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
            long id = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            Game.EventSystem.Publish(new CreateTowerDefenceSolo() { myId = id, zoneScene = self.DomainScene() });
        }

        public static void OnPvpButton(this DlgMenuUI self)
        {
            long id = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            long opponentId = IdGenerater.Instance.GenerateId();
            Game.EventSystem.Publish(new CreateTowerDefencePvp() { myId = id, zoneScene = self.DomainScene(), opponentId = opponentId });
        }

        public static void OnTeamButton(this DlgMenuUI self)
        {
            long id = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            long myIndex = 0;
            long opponentId = IdGenerater.Instance.GenerateId();
            long opponentIndex = 1;
            Game.EventSystem.Publish(new CreateTowerDefenceTeam()
            {
                myId = id,
                zoneScene = self.DomainScene(),
                opponentId = opponentId,
                myIndex = myIndex,
                opponentIndex = opponentIndex
            });
        }
    }
}