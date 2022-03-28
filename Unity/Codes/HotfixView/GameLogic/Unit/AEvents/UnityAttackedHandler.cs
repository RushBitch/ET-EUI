using DG.Tweening;
using ET.EventType;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class UnityAttackedHandler:AEvent<UnitAttacked>
    {
        protected override async ETTask Run(UnitAttacked args)
        {
            if (!args.unit.IsDisposed)
            {
                ResourcesComponent.Instance.LoadBundle("ui.unity3d");
                GameObject bundle = (GameObject) ResourcesComponent.Instance.GetAsset("ui.unity3d", "DamageLabel");
                GameObject gameObject = UnityEngine.Object.Instantiate(bundle);
                gameObject.GetComponent<RectTransform>().SetParent(GlobalComponent.Instance.PopUpRoot, true);
                GameObjectComponent gameObjectComponent = args.unit.GetComponent<GameObjectComponent>();
                Camera camera = args.unit.DomainScene().GetComponent<MainCameraComponent>().camera;
                Camera uicamera = args.unit.DomainScene().GetComponent<MainCameraComponent>().uiCamera;
                Vector3 screenPoint = camera.WorldToScreenPoint(gameObjectComponent.GameObject.transform.position);
                Vector2 position = default;
                RectTransform rectTransform = GlobalComponent.Instance.OtherRoot.GetComponent<RectTransform>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, uicamera, out position);
                gameObject.GetComponent<RectTransform>().anchoredPosition3D = position;
                gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
                gameObject.GetComponent<Text>().text = args.damage.ToString();
                position.y += 80;
                position.x += RandomHelper.RandomNumber(-20,20);
                var s = DOTween.Sequence();
                gameObject.GetComponent<RectTransform>().DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.3f);
                Text text = gameObject.GetComponent<Text>();
                Color color = text.color;
                color.a = 0.2f;
                
                s.Append(gameObject.GetComponent<RectTransform>().DOJumpAnchorPos(position, 5f, 1, 0.5f));
                s.Insert(0.4f,gameObject.GetComponent<Text>().DOColor(color, 0.1f));
                TweenCallback callback = () =>
                {
                    UnityEngine.Object.Destroy(gameObject);
                };
                s.AppendCallback(callback);
                await ETTask.CompletedTask;
            }
        }
    }
}