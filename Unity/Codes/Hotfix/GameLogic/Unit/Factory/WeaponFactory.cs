using ET.EventType;

namespace ET
{
    public static class WeaponFactory
    {
        public static Unit Create(Scene scene, int configId, long towerDefenceID, int damage,Unit enemy,Unit hero)
        {
            Unit weapon = MyUnitFactory.Create(scene, configId);
            weapon.AddComponent<TowerDefenceIdComponent, long>(towerDefenceID);
            WeaponComponent weaponComponent = weapon.AddComponent<WeaponComponent>();
            weaponComponent.enemy = enemy;
            weaponComponent.hero = hero;
            weaponComponent.damage = damage;
            weaponComponent.speed = weapon.Config.Speed;
            Game.EventSystem.Publish(new AfterCreateWeapon() { unit = weapon });
            return weapon;
        }
    }
}