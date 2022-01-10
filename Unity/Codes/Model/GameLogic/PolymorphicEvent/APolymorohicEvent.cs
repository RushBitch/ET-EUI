using System;

namespace ET
{
    public interface IPolumorohicEvent
    {
        Type GetEneityType();
        Type GetEventType();
    }

    [PolymorphicEvent]
    public abstract class APolumorohicEvent<A, B>: IPolumorohicEvent
    {
        public Type GetEneityType()
        {
            return typeof (A);
        }

        public Type GetEventType()
        {
            return typeof (B);
        }

        protected abstract void Handle(Entity entity);
    }
}