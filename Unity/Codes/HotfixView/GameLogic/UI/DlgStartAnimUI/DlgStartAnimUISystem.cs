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
            self.StartShowAnim();
        }

        private static void StartShowAnim(this DlgStartAnimUI self)
        {
            Sequence sequenceTop = DOTween.Sequence();
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-350, 0.8f).SetEase(Ease.OutCirc));
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-185, 0.8f).SetEase(Ease.OutCirc));
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-185, 0.5f).SetEase(Ease.OutCirc));
            sequenceTop.Append(self.View.EG_TopBarRectTransform.DOLocalMoveX(-1000, 0.6f));
            sequenceTop.AppendCallback(() =>
            {
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_StartAnimUI);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_TowerDefenceUI);
            });
            Sequence sequenceButtom = DOTween.Sequence();
            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(350, 0.8f).SetEase(Ease.OutCirc));
            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(185, 0.8f).SetEase(Ease.OutCirc));
            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(185, 0.5f).SetEase(Ease.OutCirc));

            sequenceButtom.Append(self.View.EG_ButtonBarRectTransform.DOLocalMoveX(1000, 0.6f));

            Sequence sequenceTopText = DOTween.Sequence();
            sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(-100, 0.8f).SetEase(Ease.OutCirc));
            sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(150, 0.4f).SetEase(Ease.OutCirc));
            sequenceTopText.Insert(1f, self.View.E_VTextImage.rectTransform.DOScaleX(0.8f, 0.2f));
            sequenceTopText.Insert(1f, self.View.E_VTextImage.rectTransform.DOScaleY(1.3f, 0.2f));
            sequenceTopText.Insert(1.2f, self.View.E_VTextImage.rectTransform.DOScaleX(1f, 0.2f));
            sequenceTopText.Insert(1.2f, self.View.E_VTextImage.rectTransform.DOScaleY(1f, 0.2f));
            sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(150, 0.5f).SetEase(Ease.OutCirc));
            sequenceTopText.Append(self.View.E_VTextImage.rectTransform.DOLocalMoveX(0, 0.6f));

            Sequence sequenceButtomText = DOTween.Sequence();
            sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(100, 0.8f).SetEase(Ease.OutCirc));
            sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(-150, 0.4f).SetEase(Ease.OutCirc));
            sequenceButtomText.Insert(1f, self.View.E_STextImage.rectTransform.DOScaleX(0.8f, 0.2f));
            sequenceButtomText.Insert(1f, self.View.E_STextImage.rectTransform.DOScaleY(1.3f, 0.2f));
            sequenceButtomText.Insert(1.2f, self.View.E_STextImage.rectTransform.DOScaleX(1f, 0.2f));
            sequenceButtomText.Insert(1.2f, self.View.E_STextImage.rectTransform.DOScaleY(1f, 0.2f));
            sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(-150, 0.5f).SetEase(Ease.OutCirc));
            sequenceButtomText.Append(self.View.E_STextImage.rectTransform.DOLocalMoveX(0, 0.6f));
        }
    }
}