using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class MoveWithListComponent:Entity, IAwake, IUpdate
    {
        public List<Vector3> pathList;
        public bool canMove;
        public int pathIndex;
        public Vector3 targetPoint;
        public float moveDistance;
        public Action finishCallback;
        public RecordMaxMoveDistanceComponent recordMaxMoveDistanceComponent;
    }
}