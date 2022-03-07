using UnityEngine;

namespace ET
{
    public class HeroLookAtEnemyComponentUpdqateSystem:UpdateSystem<HeroLookAtEnemyComponent>
    {
        public override void Update(HeroLookAtEnemyComponent self)
        {
            self.Update();
        }
    }
    public static class HeroLookAtEnemyComponentSystem
    {
        public static void Update(this HeroLookAtEnemyComponent self)
        {
            Unit enemy = self.Parent.GetComponent<AttackComponent>().attackEnemy;
            if (enemy == null)
            {
                return;
            }

            GameObject gameObject = self.Parent.GetComponent<GameObjectComponent>().GameObject;
            Vector3 forward = Vector3.Lerp(gameObject.transform.forward,
                Vector3.Scale((enemy.Position - self.GetParent<Unit>().Position).normalized,self.scaleOffset), 0.2f);
            gameObject.transform.forward = forward;
        }
    }
}