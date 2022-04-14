using UnityEngine;

namespace ET
{
    public class MainCameraComponentAwakeSystem: AwakeSystem<MainCameraComponent>
    {
        public override void Awake(MainCameraComponent self)
        {
            MainCameraComponent.Instance = self;
            self.Awake();
        }
    }

    public static class MainCameraComponentSystem
    {
        public static void Awake(this MainCameraComponent self)
        {
            self.cameraGameObject = GameObject.Find("Global/MainCamera");
            self.uiCameraGameObject = GameObject.Find("Global/UICamera");
            self.MenuHeroCamera = GameObject.Find("Global/MenuHeroCamera");
            self.camera = self.cameraGameObject.GetComponent<Camera>();
            self.uiCamera = self.uiCameraGameObject.GetComponent<Camera>();
        }
    }
}