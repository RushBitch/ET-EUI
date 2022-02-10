using ET.EventType;

namespace ET
{
    public class WeaponComponentAwakeSystem: AwakeSystem<WeaponComponent>
    {
        public override void Awake(WeaponComponent self)
        {
            self.Awake();
        }
    }

    public class WeaponComponentUpdateSystem: UpdateSystem<WeaponComponent>
    {
        public override void Update(WeaponComponent self)
        {
            self.Update();
        }
    }

    public static class WeaponComponentSystem
    {
        public static void Awake(this WeaponComponent self)
        {
            self.state = WeaponState.Null;
            NumericalComponent numericComponent = self.AddComponent<NumericalComponent>();
            numericComponent.Set(NumericalType.HeroDamageBase, 5);
            numericComponent.Set(NumericalType.HeroSpeedBase, 1);
            self.EnterNextState();
        }

        public static void Update(this WeaponComponent self)
        {
            if (self.stop)
                return;
            float delta = MyTimeHelper.GetDeltaTime() * 1000;
            if (delta > 200)
                return;
            self.currentTiem += delta;
            if (self.currentTiem >= self.targetTime)
            {
                self.EnterNextState();
            }
        }

        private static void EnterNull(this WeaponComponent self)
        {
            self.targetTime = 500;
            self.currentTiem = 0f;
            self.state = WeaponState.Null;
        }

        private static void EnterReady(this WeaponComponent self)
        {
            //获取敌人并判断敌人血量是否能够死亡，如果可以则让其置为预死亡，同时移除它的最远距离
            long id = self.Parent.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = self.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(id);

            Unit enemy = towerDefence.GetComponent<RecordMaxMoveDistanceComponent>().unit;

            if (enemy != null)
            {
                if (enemy.GetComponent<LifeComponent>().preDead)
                {
                    //Log.Info("敌人已经预死亡了");
                }

                enemy.GetComponent<LifeComponent>().PreAttacked(self.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage));
                self.attackEnemy = enemy;
            }
            else
            {
                self.EnterNull();
                self.attackEnemy = null;
            }

            self.targetTime = 100;
            self.currentTiem = 0f;
            self.state = WeaponState.Ready;
        }

        private static void EnterAttack(this WeaponComponent self)
        {
            if (self.attackEnemy != null)
            {
                Unit weapon = MyUnityFactory.Create(self.DomainScene(), UnitType.Weapon);
                weapon.AddComponent<TowerDefenceIdComponent, long>(self.Parent.GetComponent<TowerDefenceIdComponent>().ID);
                Game.EventSystem.Publish(new AfterCreateWeapon(){unit = weapon});
                weapon.GetComponent<AttackComponent>().enemy = self.attackEnemy;
                weapon.GetComponent<AttackComponent>().damage = self.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroDamage);
                weapon.GetComponent<AttackComponent>().speed = 20;
                weapon.GetComponent<AttackComponent>().SetPosition(self.GetParent<Unit>().Position);
                weapon.GetComponent<AttackComponent>().StartAttack();
            }

            self.targetTime = 100;
            self.currentTiem = 0f;
            self.state = WeaponState.Attack;
        }

        private static void EnterRest(this WeaponComponent self)
        {
            self.targetTime = 500;
            self.currentTiem = 0f;
            self.state = WeaponState.Rest;
        }

        private static void EnterNextState(this WeaponComponent self)
        {
            switch (self.state)
            {
                case WeaponState.Null:
                    self.EnterReady();
                    return;
                case WeaponState.Ready:
                    self.EnterAttack();
                    return;
                case WeaponState.Attack:
                    self.EnterRest();
                    return;
                case WeaponState.Rest:
                    self.EnterReady();
                    return;
            }
        }

        public static void StopAttack(this WeaponComponent self)
        {
            self.stop = true;
            self.EnterNull();
        }

        public static void PuseAttack(this WeaponComponent self)
        {
            self.stop = true;
        }

        public static void ResumeAttack(this WeaponComponent self)
        {
            self.stop = false;
        }
    }
}