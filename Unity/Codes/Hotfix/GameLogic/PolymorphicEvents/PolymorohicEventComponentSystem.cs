using System;
using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class PolymorohicEventAwakeComponentSystem:AwakeSystem<PolymorohicEventComponent>
    {
        public override void Awake(PolymorohicEventComponent self)
        {
            self.Awake();
        }
    }

    public static class PolymorohicEventComponentSystem
    {
        public static void Awake(this PolymorohicEventComponent self)
        {
            self.allEvents.Clear();
            var types = EventSystem.Instance.GetTypes(typeof (PolymorphicEventAttribute));
            foreach (Type type in types)
            {
                IPolumorohicEvent obj = Activator.CreateInstance(type) as IPolumorohicEvent;
                if (obj == null)
                {
                    throw new Exception($"type not is APolumorohicEvent: {obj.GetType().Name}");
                }

                Type eventType = obj.GetEventType();
                if (!self.allEvents.ContainsKey(eventType))
                {
                    self.allEvents.Add(eventType, new List<object>());
                }
                Log.Info(obj.ToString());
                self.allEvents[eventType].Add(obj);
            }
            
        }
    }
    
    
}