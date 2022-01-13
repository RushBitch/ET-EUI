using System.Collections.Generic;

namespace ET
{
    public class EnemySpawnComponentAwakeSystem: AwakeSystem<EnemySpawnComponent>
    {
        public override void Awake(EnemySpawnComponent self)
        {
            self.idSpawnPoint = new Dictionary<long, EnemySpawnPoint>();
        }
    }

    public static class EnemySpawnComponentSystem
    {
        public static void Add(this EnemySpawnComponent self, EnemySpawnPoint point)
        {
            if (!self.idSpawnPoint.ContainsKey(point.Id))
            {
                self.idSpawnPoint.Add(point.Id, point);
            }
        }

        public static void Remove(this EnemySpawnComponent self, long id)
        {
            if (!self.idSpawnPoint.ContainsKey(id))
            {
                self.idSpawnPoint.Remove(id);
            }
        }

        public static EnemySpawnPoint Get(this EnemySpawnComponent self, long id)
        {
            EnemySpawnPoint point;
            self.idSpawnPoint.TryGetValue(id, out point);
            return point;
        }
    }
}