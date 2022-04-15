using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgStartAnimUISystem
    {
        public static void RegisterUIEvent(this DlgStartAnimUI self)
        {
        }

        public static void ShowWindow(this DlgStartAnimUI self, Entity contextData = null)
        {
            self.PlaySound().Coroutine();
            self.StartShowAnim();
        }

        public static async ETTask PlaySound(this DlgStartAnimUI self)
        {
            await TimerComponent.Instance.WaitAsync(500);
        }

        private static void StartShowAnim(this DlgStartAnimUI self)
        {
            Vector3 vPos = self.View.E_VTextImage.rectTransform.anchoredPosition3D;
            Vector3 sPos = self.View.E_STextImage.rectTransform.anchoredPosition3D;
            vPos.x = -1000;
            sPos.x = 1000;
            self.View.E_VTextImage.rectTransform.anchoredPosition3D = vPos;
            self.View.E_STextImage.rectTransform.anchoredPosition3D = sPos;
            Action vsCallback = () =>
            {
                Sequence sequenceTopText = DOTween.Sequence();
                //sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(-100, 0.8f).SetEase(Ease.OutCirc));
                sequenceTopText.AppendCallback(() => { SoundComponent.Instance.Play(Sound.VS碰撞音效); });
                sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(150, 0.6f).SetEase(Ease.OutCirc));
                sequenceTopText.Insert(0.4f, self.View.E_VTextImage.rectTransform.DOScaleX(0.8f, 0.2f));
                sequenceTopText.Insert(0.4f, self.View.E_VTextImage.rectTransform.DOScaleY(1.3f, 0.2f));
                sequenceTopText.Insert(0.6f, self.View.E_VTextImage.rectTransform.DOScaleX(1f, 0.2f));
                sequenceTopText.Insert(0.6f, self.View.E_VTextImage.rectTransform.DOScaleY(1f, 0.2f));
                // sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(150, 0.5f).SetEase(Ease.OutCirc));
                // sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(0, 0.6f));

                Sequence sequenceButtomText = DOTween.Sequence();
                //sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(100, 0.8f).SetEase(Ease.OutCirc));
                sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(-150, 0.6f).SetEase(Ease.OutCirc));
                sequenceButtomText.Insert(0.4f, self.View.E_STextImage.rectTransform.DOScaleX(0.8f, 0.2f));
                sequenceButtomText.Insert(0.4f, self.View.E_STextImage.rectTransform.DOScaleY(1.3f, 0.2f));
                sequenceButtomText.Insert(0.6f, self.View.E_STextImage.rectTransform.DOScaleX(1f, 0.2f));
                sequenceButtomText.Insert(0.6f, self.View.E_STextImage.rectTransform.DOScaleY(1f, 0.2f));
                sequenceButtomText.AppendCallback(() =>
                {
                    self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_StartAnimUI);
                    self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_TowerDefenceUI);
                });
                // sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(-150, 0.5f).SetEase(Ease.OutCirc));
                // sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(0, 0.6f));
            };

            Vector3 TopPos = self.View.EG_TopBarRectTransform.anchoredPosition3D;
            Vector3 ButtomPos = self.View.EG_ButtonBarRectTransform.anchoredPosition3D;
            TopPos.x = -1000;
            ButtomPos.x = 1000;
            self.View.EG_TopBarRectTransform.anchoredPosition3D = TopPos;
            self.View.EG_ButtonBarRectTransform.anchoredPosition3D = ButtomPos;

            SoundComponent.Instance.Play(Sound.匹配界面鼓声);
            Sequence sequenceTop = DOTween.Sequence();
            //sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-350, 0.8f).SetEase(Ease.OutCirc));
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-185, 1.6f).SetEase(Ease.OutCirc));
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-185, 0.5f).SetEase(Ease.OutCirc));
            //sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-1000, 0.6f));

            Sequence sequenceButtom = DOTween.Sequence();
            //sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(350, 0.8f).SetEase(Ease.OutCirc));
            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(185, 1.6f).SetEase(Ease.OutCirc));
            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(185, 0.5f).SetEase(Ease.OutCirc));
            sequenceButtom.AppendCallback(() => { vsCallback(); });
            //sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(1000, 0.6f));
        }
    }
}