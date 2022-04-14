using UnityEngine;

namespace ET
{
    public class MainCameraComponent:Entity, IAwake
    {
        public static MainCameraComponent Instance;
        public GameObject cameraGameObject;
        public GameObject uiCameraGameObject;
        public Camera camera;
        public Camera uiCamera;
        public GameObject MenuHeroCamera;
    }
}