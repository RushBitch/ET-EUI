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
            MainCameraComponent.Instance.MenuHeroCamera.GetComponent<Camera>().enabled = true;
            MainCameraComponent.Instance.cameraGameObject.GetComponent<Camera>().enabled = false;
            GlobalComponent.Instance.OtherRoot.Find("Bg").gameObject.SetActive(true);
            self.View.EButton_Pvp.gameObject.SetActive(true);
            self.PlayMusice().Coroutine();
        }

        public static async ETTask PlayMusice(this DlgMenuUI self)
        {
            await TimerComponent.Instance.WaitAsync(1000);
            BgmComponent.Instance.Play(Music.首页BGM,1);
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
            PlayerFactory.Create(self.DomainScene(), id);
            PlayerFactory.Create(self.DomainScene(), opponentId);
            Game.EventSystem.Publish(new CreateTowerDefencePvp() { myId = id, zoneScene = self.DomainScene(), opponentId = opponentId });
            self.View.EButton_Pvp.gameObject.SetActive(false);
            BgmComponent.Instance.Stop();
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