using System.Collections.Generic;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class HeroSpawnComponentAwakeSystem: AwakeSystem<HeroSpawnComponent>
    {
        public override void Awake(HeroSpawnComponent self)
        {
            self.idIndexHero = new Dictionary<long, Dictionary<int, Unit>>();
        }
    }

    public static class HeroSpawnComponentSystem
    {
        public static void init(this HeroSpawnComponent self, long id, List<int> indexList)
        {
            Dictionary<int, Unit> indexHero = new Dictionary<int, Unit>();
            for (int i = 0; i < indexList.Count; i++)
            {
                indexHero.Add(indexList[i], null);
            }

            self.idIndexHero.Add(id, indexHero);
        }

        public static bool Add(this HeroSpawnComponent self, long playerId, Unit hero, int index)
        {
            Dictionary<int, Unit> indexHeros;
            self.idIndexHero.TryGetValue(playerId, out indexHeros);
            if (indexHeros != null)
            {
                Unit getHero;
                if (!indexHeros.ContainsKey(index))
                {
                    return false;
                }

                indexHeros.TryGetValue(index, out getHero);
                if (getHero != null)
                {
                    return false;
                }
                else
                {
                    indexHeros[index] = hero;
                    hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroIndexBase, index);
                    return true;
                }
            }
            else
            {
                Log.Error($"无法找到id{playerId}:此HeroSpawnComponent的indexHeros");
                return false;
            }
        }

        public static bool Change(this HeroSpawnComponent self, long playerId, Unit hero, int index)
        {
            Dictionary<int, Unit> indexHeros;
            self.idIndexHero.TryGetValue(playerId, out indexHeros);
            if (indexHeros != null)
            {
                if (!indexHeros.ContainsKey(index))
                {
                    return false;
                }

                Unit getHero;
                indexHeros.TryGetValue(index, out getHero);
                if (getHero != null)
                {
                    int tempIndex = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroIndex);
                    indexHeros[index] = hero;
                    hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroIndexBase, index);

                    indexHeros[tempIndex] = getHero;
                    getHero.GetComponent<NumericalComponent>().Set(NumericalType.HeroIndexBase, tempIndex);

                    return false;
                }
                else
                {
                    indexHeros[index] = hero;
                    hero.GetComponent<NumericalComponent>().Set(NumericalType.HeroIndexBase, index);
                    return true;
                }
            }
            else
            {
                Log.Error($"无法找到id{playerId}:此HeroSpawnComponent的indexHeros");
                return false;
            }
        }

        public static void Remove(this HeroSpawnComponent self, long playerId, Unit hero)
        {
            Dictionary<int, Unit> indexHeros;
            self.idIndexHero.TryGetValue(playerId, out indexHeros);
            if (indexHeros != null)
            {
                int index = hero.GetComponent<NumericalComponent>().GetAsInt(NumericalType.HeroIndex);
                if (indexHeros.ContainsKey(index))
                {
                    indexHeros[index] = null;
                }
            }
            else
            {
                Log.Error($"无法找到id{playerId}:此HeroSpawnComponent的indexHeros");
            }
        }

        public static void SpawnRandomHero(this HeroSpawnComponent self, long id)
        {
            Dictionary<int, Unit> indexHeros;
            self.idIndexHero.TryGetValue(id, out indexHeros);
            List<int> indexs = new List<int>();
            foreach (var indexHero in indexHeros)
            {
                if (indexHero.Value == null)
                {
                    indexs.Add(indexHero.Key);
                }
            }

            if (indexs.Count > 0)
            {
                int random = RandomHelper.RandomNumber(0, indexs.Count);
                int configId = 1100 + RandomHelper.RandomNumber(2, 7);
                Unit hero = HeroFactory.Create(self.DomainScene(), 1107, self.Id, indexs[random], 1);
                self.Add(id, hero, indexs[random]);
            }
            else
            {
                Log.Info("英雄已满");
            }
        }

        public static void SpawnRandomHeroWithIndex(this HeroSpawnComponent self, long id, int index, int level)
        {
            int configId = 1100 + RandomHelper.RandomNumber(2, 7);
            Unit hero = HeroFactory.Create(self.DomainScene(), 1107, self.Id, index, level + 1);
            self.Add(id, hero, index);
        }
    }
}