using System;
using System.Collections.Generic;
using ILRuntime.Runtime;
using UnityEngine;

namespace ET
{
    public partial class BattlefieldEnemyPathConfig
    {
        public List<Vector3> pathList;

        public override void EndInit()
        {
            base.AfterEndInit();
            pathList = new List<Vector3>();
            ParsePathDataToList(ref pathList, path);
        }

        private void ParsePathDataToList(ref List<Vector3> pathList, string pathData)
        {
            string[] stringsArr = pathData.Split(',');
            for (int i = 0; i < stringsArr.Length; i++)
            {
                Vector3 pos = new Vector3();
                int x = stringsArr[i].ToInt32() % 7;
                int y = stringsArr[i].ToInt32() / 7;
                pos.x = x + x / 12f - 3.25f;
                pos.y = 0;
                pos.z = y + y / 12f - 5.75f;
                pathList.Add(pos);
            }
        }
    }
}