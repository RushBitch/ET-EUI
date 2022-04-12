using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgSettleUISystem
    {
        public static void RegisterUIEvent(this DlgSettleUI self)
        {
            self.View.EButton_BackToMainButton.AddListener(self.OnBackToMainButton);
        }

        public static void ShowWindow(this DlgSettleUI self, Entity contextData = null)
        {
        }

        public static void ShowWin(this DlgSettleUI self, Entity contextData = null)
        {
            self.View.EG_VicyoryRectTransform.gameObject.SetActive(false);
            self.View.EG_LoseRectTransform.gameObject.SetActive(false);
            self.View.EG_CoinRectTransform.gameObject.SetActive(false);
            self.View.EG_TrophyRectTransform.gameObject.SetActive(false);
            self.View.EButton_BackToMainButton.gameObject.SetActive(false);
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => { self.View.EG_VicyoryRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_VicyoryRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EG_CoinRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_CoinRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EG_TrophyRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_TrophyRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EButton_BackToMainButton.gameObject.SetActive(true); });
            sequence.Append(self.View.EButton_BackToMainButton.gameObject.GetComponent<RectTransform>().DOShakeScale(0.7f));
        }
        public static void ShowLose(this DlgSettleUI self, Entity contextData = null)
        {
            self.View.EG_VicyoryRectTransform.gameObject.SetActive(false);
            self.View.EG_LoseRectTransform.gameObject.SetActive(false);
            self.View.EG_CoinRectTransform.gameObject.SetActive(false);
            self.View.EG_TrophyRectTransform.gameObject.SetActive(false);
            self.View.EButton_BackToMainButton.gameObject.SetActive(false);
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => { self.View.EG_LoseRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_LoseRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EG_CoinRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_CoinRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EG_TrophyRectTransform.gameObject.SetActive(true); });
            sequence.Append(self.View.EG_TrophyRectTransform.DOShakeScale(0.7f));
            sequence.AppendCallback(() => { self.View.EButton_BackToMainButton.gameObject.SetActive(true); });
            sequence.Append(self.View.EButton_BackToMainButton.gameObject.GetComponent<RectTransform>().DOShakeScale(0.7f));
        }
        public static void OnBackToMainButton(this DlgSettleUI self)
        {
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SettleUI);
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

            BgmComponent.Instance.Stop();
        }
    }
}