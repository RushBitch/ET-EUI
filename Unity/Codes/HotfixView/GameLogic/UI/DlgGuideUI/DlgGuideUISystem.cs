using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class DlgGuideUISystem
    {
        public static void RegisterUIEvent(this DlgGuideUI self)
        {
        }

        public static void ShowWindow(this DlgGuideUI self, Entity contextData = null)
        {
            self.EnterGuide1().Coroutine();
        }

        public static async ETTask EnterGuide1(this DlgGuideUI self)
        {
            self.View.EG_BgRectTransform.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.85f);
            await TimerComponent.Instance.WaitFrameAsync();
            UIComponent uiComponent = self.DomainScene().GetComponent<UIComponent>();
            uiComponent.VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out UIBaseWindow window);
            DlgTowerDefenceUI ui = window.GetComponent<DlgTowerDefenceUI>();
            GameObject gameObject = ui.View.EButton_CreateHeroButton.gameObject;

            Action action = () =>
            {
                ui.OnCreateHero(true);
                self.View.EG_BgRectTransform.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                self.EnterGuide2().Coroutine();
            };

            self.FinderGuide(gameObject, action);
        }

        public static async ETTask EnterGuide2(this DlgGuideUI self)
        {
            await TimerComponent.Instance.WaitAsync(1500);
            self.View.EG_BgRectTransform.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.85f);
            UIComponent uiComponent = self.DomainScene().GetComponent<UIComponent>();
            uiComponent.VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out UIBaseWindow window);
            DlgTowerDefenceUI ui = window.GetComponent<DlgTowerDefenceUI>();
            GameObject gameObject = ui.View.EButton_CreateHeroButton.gameObject;

            Action action = () =>
            {
                ui.OnCreateHero(true);
                self.View.EG_BgRectTransform.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                self.EnterGuide3().Coroutine();
            };

            self.FinderGuide(gameObject, action);
        }

        public static async ETTask EnterGuide3(this DlgGuideUI self)
        {
            await TimerComponent.Instance.WaitAsync(1000);
            TowerDefenceCompoment towerDefenceCompoment = self.DomainScene().GetComponent<TowerDefenceCompoment>();
            long myId = self.DomainScene().GetComponent<PlayerComponent>().MyId;
            towerDefenceCompoment.playerIdTowerDefences.TryGetValue(myId, out TowerDefence towerDefence);
            long tdID = towerDefence.Id;
            UnitComponent unitComponent = self.DomainScene().GetComponent<UnitComponent>();
            List<Unit> units = new List<Unit>();
            foreach (var unit in unitComponent.Children.Values)
            {
                TowerDefenceIdComponent towerDefenceIdComponent = unit.GetComponent<TowerDefenceIdComponent>();
                if (towerDefenceIdComponent != null && towerDefenceIdComponent.ID == tdID)
                {
                    if (unit.GetComponent<AttackComponent>() != null)
                    {
                        units.Add((Unit) unit);
                    }
                }
            }
            
            if (units.Count >= 2)
            {
                Vector3 startPos = units[0].GetComponent<GameObjectComponent>().GameObject.transform.position;
                Vector3 endPos = units[1].GetComponent<GameObjectComponent>().GameObject.transform.position;
                HeroCompoundComponent heroCompoundComponent = towerDefenceCompoment.GetComponent<HeroCompoundComponent>();
                heroCompoundComponent.compoundCallback = () =>
                {
                    self.EndTouchMoveGuide();
                    UIComponent uiComponent = self.DomainScene().GetComponent<UIComponent>();
                    uiComponent.HideWindow(WindowID.WindowID_GuideUI);
                    uiComponent.VisibleWindowsDic.TryGetValue((int) WindowID.WindowID_TowerDefenceUI, out UIBaseWindow window);
                    window.GetComponent<DlgTowerDefenceUI>().StartAsync().Coroutine();
                    PlayerPrefs.SetInt("Guided", 4);
                };
                self.StartTouchMoveGuide(startPos, endPos);
            }
        }

        public static void FinderGuide(this DlgGuideUI self, GameObject gameObject, Action action)
        {
            GameObject obj = UnityEngine.Object.Instantiate(gameObject, self.View.uiTransform);
            Button button = obj.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.AddListener(() =>
            {
                self.View.EG_FingerRectTransform.gameObject.SetActive(false);
                action.Invoke();
                UnityEngine.Object.Destroy(obj);
            });
            var position = gameObject.transform.position;
            obj.transform.position = position;
            self.View.EG_FingerRectTransform.gameObject.SetActive(true);
            self.View.EG_FingerRectTransform.position = position;
            self.View.EG_FingerRectTransform.SetSiblingIndex(self.View.EG_FingerRectTransform.parent.childCount);
        }

        public static void StartTouchMoveGuide(this DlgGuideUI self, Vector3 startPos, Vector3 endPos)
        {
            self.View.EG_BgRectTransform.gameObject.SetActive(false);
            Camera camera = self.DomainScene().GetComponent<MainCameraComponent>().camera;
            Camera uicamera = self.DomainScene().GetComponent<MainCameraComponent>().uiCamera;
            startPos = camera.WorldToScreenPoint(startPos);
            endPos = camera.WorldToScreenPoint(endPos);
            Vector2 startPos2 = default;
            Vector2 endPos2 = default;
            RectTransform rectTransform = GlobalComponent.Instance.OtherRoot.GetComponent<RectTransform>();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, startPos, uicamera, out startPos2);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, endPos, uicamera, out endPos2);
            self.TouchSequence = DOTween.Sequence();
            ;
            self.TouchSequence.AppendCallback(() => { self.View.EG_TouchFingerRectTransform.gameObject.SetActive(true); });
            self.TouchSequence.AppendCallback(() => { self.View.EG_TouchFingerRectTransform.anchoredPosition3D = startPos2; });
            self.TouchSequence.Append(self.View.EG_TouchFingerRectTransform.DOLocalMove(endPos2, 1f));
            //self.TouchSequence.Insert(0.3f,self.View.EG_TouchFingerRectTransform.gameObject.GetComponent<Image>().DOColor(new Color(1, 1, 1, 0),0.2f ));
            //self.TouchSequence.AppendCallback(() => { self.View.EG_TouchFingerRectTransform.gameObject.SetActive(false);});
            self.TouchSequence.SetLoops(100);
        }

        public static void EndTouchMoveGuide(this DlgGuideUI self)
        {
            self.View.EG_BgRectTransform.gameObject.SetActive(true);
            self.TouchSequence.Kill();
            self.TouchSequence = null;
        }
    }
}