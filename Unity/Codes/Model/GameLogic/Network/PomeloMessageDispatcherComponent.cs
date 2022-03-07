using System.Collections.Generic;

namespace ET
{
    public class PomeloMessageDispatcherComponent: Entity, IAwake, ILoad, IDestroy
    {
    public static PomeloMessageDispatcherComponent Instance
    {
        get;
        set;
    }

    public readonly Dictionary<int, List<IMHandler>> Handlers = new Dictionary<int, List<IMHandler>>();
    }
}