using ET.EventType;

namespace ET
{
    public static class PreAttackComponentSystem
    {
        public static void EnablePreAttack(this PreAttackComponent self)
        {
            foreach (var enemy in self.enemys)
            {
                if (enemy != null && !enemy.IsDisposed)
                {
                    bool isDead = enemy.GetComponent<LifeComponent>().Attacked(self.damage);
                    if (isDead)
                    {
                        Game.EventSystem.Publish(new EnemyKilledByHero() { id = self.Parent.GetComponent<TowerDefenceIdComponent>().ID });
                    }
                }
            }
            self.enemys.Clear();
        }
    }
}