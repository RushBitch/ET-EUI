using ET.EventType;

namespace ET
{
    public static class PreAttackComponentSystem
    {
        public static void EnablePreAttack(this PreAttackComponent self)
        {
            if (self.enemy != null && !self.enemy.IsDisposed)
            {
                bool isDead = self.enemy.GetComponent<LifeComponent>().Attacked(self.damage);
                if (isDead)
                {
                    Game.EventSystem.Publish(new EnemyKilledByHero() { id = self.Parent.GetComponent<TowerDefenceIdComponent>().ID });
                }
            }
        }
    }
}