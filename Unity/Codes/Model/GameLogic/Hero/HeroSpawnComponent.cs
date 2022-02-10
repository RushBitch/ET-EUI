using System.Collections.Generic;

namespace ET
{
    public class HeroSpawnComponent:Entity, IAwake
    {
        public Dictionary<long, Dictionary<int, Unit>> idIndexHero;
    }
}