using System;
using System.Collections.Generic;

namespace ET
{
    public class PolymorohicEventComponent:Entity, IAwake
    {
        public readonly Dictionary<Type, List<object>> allEvents = new Dictionary<Type, List<object>>();
    }
}