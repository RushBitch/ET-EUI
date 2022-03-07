using ET.EventType;

namespace ET
{
    public static class HeroFactory
    {
        public static Unit Create(Scene scene, int configId, long towerDefenceID,int index,int level)
        {
            Unit hero = MyUnitFactory.Create(scene, configId);
            HeroConfig heroConfig = HeroConfigCategory.Instance.Get(hero.Config.Type);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroIndexBase, index);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroDamageBase, hero.Config.Damage);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroSpeedBase, hero.Config.Speed);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.AttackToSkillCountBase, heroConfig.AttackToSkillCount);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.SkillShowTimeBase, heroConfig.SkillShowTime);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.SkillBeforeTimeBase, heroConfig.SkillBefore);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.SkillAfterTimeBase, heroConfig.SkillAfter);
            hero.GetComponent<NumericalComponent>().Set(NumericalType.LevelBase, level);
            hero.AddComponent<TowerDefenceIdComponent, long>(towerDefenceID);
            hero.AddComponent<AttackComponent>();
            Game.EventSystem.Publish(new AfterCreateHero() { unit = hero });
            hero.AddComponent<AIComponent, int>(3);
            return hero;
        }
    }
}