using System;

namespace ET
{
    public partial class BattlefieldMapConfig
    {
        public int[][] battlefieldMap;
    
         public override void EndInit()
         {
             base.AfterEndInit();
             battlefieldMap = new int[11][];
             ParseMapDataToArray(ref battlefieldMap[0], this.row1);
             ParseMapDataToArray(ref battlefieldMap[1], this.row2);
             ParseMapDataToArray(ref battlefieldMap[2], this.row3);
             ParseMapDataToArray(ref battlefieldMap[3], this.row4);
             ParseMapDataToArray(ref battlefieldMap[4], this.row5);
             ParseMapDataToArray(ref battlefieldMap[5], this.row6);
             ParseMapDataToArray(ref battlefieldMap[6], this.row7);
             ParseMapDataToArray(ref battlefieldMap[7], this.row8);
             ParseMapDataToArray(ref battlefieldMap[8], this.row9);
             ParseMapDataToArray(ref battlefieldMap[9], this.row10);
             ParseMapDataToArray(ref battlefieldMap[10], this.row11);
         }
        
         private void ParseMapDataToArray(ref int[] arr, string mapData)
         {
             string[] stringsArr = mapData.Split(',');
             arr = new int[stringsArr.Length];
             for (int i = 0; i < stringsArr.Length; i++)
             {
                 arr[i] = Convert.ToInt32(stringsArr[i]);
             }
         }
    }

}