using System;

namespace ET
{
    public class HeroCompoundComponent: Entity, IAwake
    {
        public Unit sellectUnit;
        public Action compoundCallback;
    }
}