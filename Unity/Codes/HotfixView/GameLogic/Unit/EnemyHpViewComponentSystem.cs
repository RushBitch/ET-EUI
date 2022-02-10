using UnityEngine;

namespace ET
{
    public class EnemyHpViewDestorySystem: DestroySystem<EnemyHpViewComponent>
    {
        public override void Destroy(EnemyHpViewComponent self)
        {
            UnityEngine.Object.Destroy(self.gameObject);
        }
    }
    
    public class EnemyHpViewUpdateSystem: UpdateSystem<EnemyHpViewComponent>
    {
        public override void Update(EnemyHpViewComponent self)
        {
            Camera camera = self.DomainScene().GetComponent<MainCameraComponent>().camera;
            Camera uicamera = self.DomainScene().GetComponent<MainCameraComponent>().uiCamera;
            Vector3 screenPoint = camera.WorldToScreenPoint(self.Parent.GetComponent<GameObjectComponent>().GameObject.transform.position);
            Vector2 position = default;
            RectTransform rectTransform = GlobalComponent.Instance.OtherRoot.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, uicamera, out position);
            position.y -= 30;
            self.gameObject.GetComponent<RectTransform>().anchoredPosition3D = position;
        }
    }
}