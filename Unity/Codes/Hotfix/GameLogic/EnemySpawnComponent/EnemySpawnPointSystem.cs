using System.Numerics;

namespace ET
{
    public class EnemySpawnPointSystem:AwakeSystem<EnemySpawnPoint,Vector3>
    {
        public override void Awake(EnemySpawnPoint self, Vector3 pos)
        {
            self.spwanPoint = pos;
        }
    }
}