using System;
using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    namespace EventType
    {
        public struct EnemyBreakDefence
        {
            public Unit unit;
        }
    }

    public class MoveWithListComponentAwakeSystem: AwakeSystem<MoveWithListComponent>
    {
        public override void Awake(MoveWithListComponent self)
        {
        }
    }

    public class MoveWithListComponentUpdateSystem: UpdateSystem<MoveWithListComponent>
    {
        public override void Update(MoveWithListComponent self)
        {
            self.Update();
        }
    }

    public static class MoveWithListComponentSystem
    {
        public static void Update(this MoveWithListComponent self)
        {
            if (!self.canMove)
                return;
            float deltaTime = MyTimeHelper.GetDeltaTime();
            if (deltaTime > 0)
            {
                Unit unit = self.GetParent<Unit>();
                Vector3 forWard = (self.targetPoint - unit.Position).normalized;
                Vector3 moveInterval = forWard * deltaTime * unit.GetComponent<NumericalComponent>().GetAsInt(NumericalType.Speed) / 20f;
                self.moveDistance += moveInterval.magnitude;
                if (!unit.GetComponent<LifeComponent>().preDead)
                {
                    self.recordMaxMoveDistanceComponent.Record(self.GetParent<Unit>(), self.moveDistance);
                }

                unit.Position = unit.Position + moveInterval;
                unit.Forward = Vector3.Lerp(unit.Forward, forWard, 0.2f);
                if ((unit.Position - self.targetPoint).magnitude < 0.05)
                {
                    self.SetNextTarget();
                }
            }
        }

        public static void StartMove(this MoveWithListComponent self, List<Vector3> pathList, Action callback)
        {
            self.pathList = pathList;
            self.finishCallback = callback;
            self.pathIndex = 0;
            self.canMove = true;
            self.GetParent<Unit>().Position = self.pathList[0];
            self.SetNextTarget();
        }

        public static void StopMove(this MoveWithListComponent self)
        {
            self.canMove = false;
        }

        public static void ResumeMove(this MoveWithListComponent self)
        {
            self.canMove = true;
        }

        private static void SetNextTarget(this MoveWithListComponent self)
        {
            self.pathIndex += 1;
            if (self.pathIndex >= self.pathList.Count)
            {
                self.canMove = false;
                Game.EventSystem.Publish(new CleanMaxMoveDistance() { unit = self.GetParent<Unit>() });
                Game.EventSystem.Publish(new EnemyBreakDefence() { unit = self.GetParent<Unit>() });
                self.finishCallback?.Invoke();
                return;
            }

            self.targetPoint = self.pathList[self.pathIndex];
        }
    }
}