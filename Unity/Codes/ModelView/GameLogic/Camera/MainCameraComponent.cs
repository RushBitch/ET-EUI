using UnityEngine;

namespace ET
{
    public class MainCameraComponent:Entity, IAwake
    {
        public GameObject cameraGameObject;
        public GameObject uiCameraGameObject;
        public Camera camera;
        public Camera uiCamera;
    }
}