using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ET
{
    public class PService: AService
    {
        private readonly Dictionary<long, PChannel> idChannels = new Dictionary<long, PChannel>();

        private readonly SocketAsyncEventArgs innArgs = new SocketAsyncEventArgs();

        private Socket acceptor;

        public HashSet<long> NeedStartSend = new HashSet<long>();

        public PService(ThreadSynchronizationContext threadSynchronizationContext, ServiceType serviceType)
        {
            this.ServiceType = serviceType;
            this.ThreadSynchronizationContext = threadSynchronizationContext;
        }

        public PService(ThreadSynchronizationContext threadSynchronizationContext, IPEndPoint ipEndPoint, ServiceType serviceType)
        {
            this.ServiceType = serviceType;
            this.ThreadSynchronizationContext = threadSynchronizationContext;

            this.acceptor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.acceptor.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            this.innArgs.Completed += this.OnComplete;
            this.acceptor.Bind(ipEndPoint);
            this.acceptor.Listen(1000);

            this.ThreadSynchronizationContext.PostNext(this.AcceptAsync);
        }

        private void OnComplete(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    SocketError socketError = e.SocketError;
                    Socket acceptSocket = e.AcceptSocket;
                    this.ThreadSynchronizationContext.Post(() => { this.OnAcceptComplete(socketError, acceptSocket); });
                    break;
                default:
                    throw new Exception($"socket error: {e.LastOperation}");
            }
        }

        private void AcceptAsync()
        {
            this.innArgs.AcceptSocket = null;
            if (this.acceptor.AcceptAsync(this.innArgs))
            {
                return;
            }

            OnAcceptComplete(this.innArgs.SocketError, this.innArgs.AcceptSocket);
        }

        private void OnAcceptComplete(SocketError socketError, Socket acceptSocket)
        {
            if (this.acceptor == null)
            {
                return;
            }

            // 开始新的accept
            this.AcceptAsync();

            if (socketError != SocketError.Success)
            {
                Log.Error($"accept error {socketError}");
                return;
            }

            try
            {
                long id = this.CreateAcceptChannelId(0);
                PChannel channel = new PChannel(id, acceptSocket, this);
                this.idChannels.Add(channel.Id, channel);
                long channelId = channel.Id;

                this.OnAccept(channelId, channel.RemoteAddress);
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
        }

        private PChannel Create(IPEndPoint ipEndPoint, long id)
        {
            PChannel channel = new PChannel(id, ipEndPoint, this);
            this.idChannels.Add(channel.Id, channel);
            return channel;
        }

        protected override void Get(long id, IPEndPoint address)
        {
            if (this.idChannels.TryGetValue(id, out PChannel _))
            {
                return;
            }

            this.Create(address, id);
        }

        private PChannel Get(long id)
        {
            PChannel channel = null;
            this.idChannels.TryGetValue(id, out channel);
            return channel;
        }

        public override void Update()
        {
            // foreach (long channelId in this.NeedStartSend)
            // {
            // PChannel pChannel = this.Get(channelId);
            // pChannel?.Update();
            //}

            //this.NeedStartSend.Clear();
            foreach (var key in this.idChannels.Keys)
            {
                PChannel pChannel = this.Get(key);
                pChannel?.Update();
            }
            this.NeedStartSend.Clear();
        }

        public override void Remove(long id)
        {
            if (this.idChannels.TryGetValue(id, out PChannel channel))
            {
                channel.Dispose();
            }

            this.idChannels.Remove(id);
        }

        public override bool IsDispose()
        {
            return this.ThreadSynchronizationContext == null;
        }

        public override void Dispose()
        {
            this.acceptor?.Close();
            this.acceptor = null;
            this.innArgs.Dispose();
            ThreadSynchronizationContext = null;

            foreach (long id in this.idChannels.Keys.ToArray())
            {
                PChannel channel = this.idChannels[id];
                channel.Dispose();
            }

            this.idChannels.Clear();
        }

        protected override void Send(long channelId, long packType, MemoryStream stream)
        {
            try
            {
                PChannel aChannel = this.Get(channelId);
                if (aChannel == null)
                {
                    this.OnError(channelId, ErrorCore.ERR_SendMessageNotFoundTChannel);
                    return;
                }

                aChannel.Send((PomeloPacketType) packType, stream);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}