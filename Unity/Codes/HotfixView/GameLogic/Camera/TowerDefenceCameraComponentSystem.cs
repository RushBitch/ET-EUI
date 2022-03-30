using DG.Tweening;
using UnityEngine;

namespace ET
{
    public class TowerDefenceCameraComponentAwakeSystem: AwakeSystem<TowerDefenceCameraComponent, GameObject>
    {
        public override void Awake(TowerDefenceCameraComponent self, GameObject gameObject)
        {
            self.gameObject = gameObject;
            self.farPos = new Vector3(0, 11.57f, -11.58f);
            self.farQuaternion = Quaternion.Euler(new Vector3(130.878f, -180f, -180f));
            self.nearPos = new Vector3(0, 17.89f, -1.69f);
            self.nearQuaternion = Quaternion.Euler(new Vector3(90f, -180, -180f));
        }
    }

    public static class TowerDefenceCameraComponentSystem
    {
        public static void SwitchToFar(this TowerDefenceCameraComponent self)
        {
            self.gameObject.transform.DOMove(self.farPos, 0.5f);
            self.gameObject.transform.DORotateQuaternion(self.farQuaternion, 0.5f);
        }

        public static void SwitchToNear(this TowerDefenceCameraComponent self)
        {
            self.gameObject.transform.DOMove(self.nearPos, 0.5f);
            self.gameObject.transform.DORotateQuaternion(self.nearQuaternion, 0.5f);
        }

        public static void Shake(this TowerDefenceCameraComponent self,int time,float strength)
        {
            self.gameObject.transform.DOShakePosition(time,strength);
        }
    }
}