using System.Net;

namespace ET
{
    public class NetPcpComponent: Entity, IAwake<int>, IAwake<IPEndPoint, int>, IDestroy
    {
        public AService Service;
        
        public int SessionStreamDispatcherType { get; set; }
    }
}