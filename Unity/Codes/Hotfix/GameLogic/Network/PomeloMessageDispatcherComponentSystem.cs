using System;
using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class PomeloMessageDispatcherComponentAwakeSystem: AwakeSystem<PomeloMessageDispatcherComponent>
    {
        public override void Awake(PomeloMessageDispatcherComponent self)
        {
            PomeloMessageDispatcherComponent.Instance = self;
            self.Load();
        }
    }

    [ObjectSystem]
    public class PomeloMessageDispatcherComponentLoadSystem: LoadSystem<PomeloMessageDispatcherComponent>
    {
        public override void Load(PomeloMessageDispatcherComponent self)
        {
            self.Load();
        }
    }

    [ObjectSystem]
    public class PomeloMessageDispatcherComponentDestroySystem: DestroySystem<PomeloMessageDispatcherComponent>
    {
        public override void Destroy(PomeloMessageDispatcherComponent self)
        {
            PomeloMessageDispatcherComponent.Instance = null;
            self.Handlers.Clear();
        }
    }

    /// <summary>
    /// 消息分发组件
    /// </summary>
    public static class PomeloMessageDispatcherComponentHelper
    {
        public static void Load(this PomeloMessageDispatcherComponent self)
        {
            self.Handlers.Clear();

            HashSet<Type> types = Game.EventSystem.GetTypes(typeof (PomeloMessageHandlerAttribute));

            foreach (Type type in types)
            {
                IMHandler iMHandler = Activator.CreateInstance(type) as IMHandler;
                if (iMHandler == null)
                {
                    Log.Error($"message handle {type.Name} 需要继承 IMHandler");
                    continue;
                }

                Type messageType = iMHandler.GetMessageType();
                int routeCode = PomeloRouteInfoComponent.Instance.GetRouteCodeByTybe(messageType);
                if (routeCode == -1)
                {
                    Log.Error($"消息opcode为0: {messageType.Name}");
                    continue;
                }

                self.RegisterHandler(routeCode, iMHandler);
            }
        }

        public static void RegisterHandler(this PomeloMessageDispatcherComponent self, int routeCode, IMHandler handler)
        {
            if (!self.Handlers.ContainsKey(routeCode))
            {
                self.Handlers.Add(routeCode, new List<IMHandler>());
            }

            self.Handlers[routeCode].Add(handler);
        }

        public static void Handle(this PomeloMessageDispatcherComponent self, Session session, int routeCode, object message)
        {
            List<IMHandler> actions;
            if (!self.Handlers.TryGetValue(routeCode, out actions))
            {
                Log.Error($"消息没有处理: {routeCode} {message}");
                return;
            }

            foreach (IMHandler ev in actions)
            {
                try
                {
                    ev.Handle(session, message);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }
    }
}