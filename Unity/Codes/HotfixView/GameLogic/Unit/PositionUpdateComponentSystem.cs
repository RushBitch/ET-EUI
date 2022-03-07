﻿using UnityEngine;

namespace ET
{
    public class PositionUpdateComponentUpdateSystem: UpdateSystem<PositionUpdateComponent>
    {
        public override void Update(PositionUpdateComponent self)
        {
            self.Update();
        }
    }

    public static class PositionComponentSystem
    {
        public static void Update(this PositionUpdateComponent self)
        {
            GameObjectComponent gameObjectComponent = self.Parent.GetComponent<GameObjectComponent>();
            if (gameObjectComponent != null)
            {
                gameObjectComponent.GameObject.transform.position = Vector3.Scale(self.GetParent<Unit>().Position,self.scale) + self.offset;
                // Vector3 eulerAngles = new Vector3();
                // eulerAngles.x = self.GetParent<Unit>().Rotation.eulerAngles.x;
                // if (self.scale.z == -1)
                // {
                //     eulerAngles.y = -self.GetParent<Unit>().Rotation.eulerAngles.y;
                // }
                // else
                // {
                //     eulerAngles.y = self.GetParent<Unit>().Rotation.eulerAngles.y;
                // }
                // eulerAngles.z = self.GetParent<Unit>().Rotation.eulerAngles.z;
                // gameObjectComponent.GameObject.transform.eulerAngles = eulerAngles;
            }
        }
    }
}