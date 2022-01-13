using UnityEngine;

namespace ET
{
    public class SpawnPointViewAwakeSystem: AwakeSystem<EnemySpawnPointView, GameObject>
    {
        public override void Awake(EnemySpawnPointView self, GameObject gameObject)
        {
            self.gameObject = gameObject;
            EnemySpawnPoint enemySpawnPoint = (EnemySpawnPoint) self.Parent;
            Vector3 pos = new Vector3();
            pos.x = enemySpawnPoint.spwanPoint.X;
            pos.y = enemySpawnPoint.spwanPoint.Y;
            pos.z = enemySpawnPoint.spwanPoint.Z;
            Log.Info(pos.ToString());
            self.gameObject.transform.localPosition = pos;
        }
    }
}