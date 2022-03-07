using System.Collections.Generic;
using ET.EventType;

namespace ET
{
    public static class AddAttackDamageSkillComponentSystem
    {
        public static async void Add(this AddAttackDamageSkillComponent self)
        {
            int index = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroIndex);
            List<int> heroIndexs = new List<int>() { index - 1, index + 1, index - 7, index + 7 };
            List<Unit> buffList = new List<Unit>();
            long towenDefecneID = self.Parent.GetComponent<TowerDefenceIdComponent>().ID;
            TowerDefence towerDefence = self.DomainScene().GetComponent<TowerDefenceCompoment>().GetChild<TowerDefence>(towenDefecneID);
            HeroSpawnComponent heroSpawnComponent = towerDefence.GetComponent<HeroSpawnComponent>();
            heroSpawnComponent.idIndexHero.TryGetValue(towerDefence.playerIds[0], out Dictionary<int, Unit> indexHeroDic);
            int skillShowTime = self.Parent.GetComponent<NumericalComponent>().GetAsInt(NumericalType.SkillShowTime);
            for (int i = 0; i < heroIndexs.Count; i++)
            {
                int heroIndex = heroIndexs[i];
                indexHeroDic.TryGetValue(heroIndex, out Unit hero);
                if (hero == null)
                {
                    continue;
                }

                if (hero.GetComponent<AttackSpeedBuffComponent>() != null)
                {
                    continue;
                }

                hero.AddComponent<AttackSpeedBuffComponent, int, int>(skillShowTime, 20);
                Game.EventSystem.Publish(new PlayerEffect()
                {
                    pos = TransformConvert.ConvertPositon(self.GetParent<Unit>(), self.GetParent<Unit>().Position),
                    effectId = 1307,
                    effectTime = skillShowTime
                });
                buffList.Add(hero);
            }

            await TimerComponent.Instance.WaitAsync(skillShowTime);
            for (int i = 0; i < buffList.Count; i++)
            {
                buffList[i]?.RemoveComponent<AttackSpeedBuffComponent>();
            }
        }
    }
}