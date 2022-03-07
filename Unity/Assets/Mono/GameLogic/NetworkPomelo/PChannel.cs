using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ET
{
    public class PChannel: AChannel
    {
        private readonly PService Service;
        private Socket socket;
        private SocketAsyncEventArgs outArgs = new SocketAsyncEventArgs();
        private SocketAsyncEventArgs innArgs = new SocketAsyncEventArgs();

        private bool isSending;
        private bool isConnected;

        private readonly CircularBuffer sendBuffer = new CircularBuffer();
        private readonly CircularBuffer recieveBuffer = new CircularBuffer();

        private readonly byte[] packetCache = new byte[PomeloPacket.PacketSize];
        private readonly PomeloPacketParser parser;

        public PChannel(long id, IPEndPoint ipEndPoint, PService service)
        {
            this.ChannelType = ChannelType.Connect;
            this.Id = id;
            this.Service = service;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.NoDelay = true;
            this.outArgs.Completed += this.OnComplete;
            this.innArgs.Completed += this.OnComplete;
            this.parser = new PomeloPacketParser(this.recieveBuffer);
            this.RemoteAddress = ipEndPoint;
            this.isConnected = false;
            this.isSending = false;

            this.Service.ThreadSynchronizationContext.PostNext(this.ConnectAsync);
        }

        public PChannel(long id, Socket socket, PService service)
        {
            this.ChannelType = ChannelType.Accept;
            this.Id = id;
            this.Service = service;
            this.socket = socket;
            this.socket.NoDelay = true;
            this.outArgs.Completed += this.OnComplete;
            this.innArgs.Completed += this.OnComplete;
            this.parser = new PomeloPacketParser(this.recieveBuffer);

            this.RemoteAddress = (IPEndPoint) socket.RemoteEndPoint;
            this.isConnected = true;
            this.isSending = false;

            // 下一帧再开始读写
            this.Service.ThreadSynchronizationContext.PostNext(() =>
            {
                this.StartRecv();
                this.StartSend();
            });
        }

        private void ConnectAsync()
        {
            this.outArgs.RemoteEndPoint = this.RemoteAddress;
            if (this.socket.ConnectAsync(this.outArgs))
            {
                return;
            }

            OnConnectComplete(this.outArgs);
        }

        private void OnComplete(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    this.Service.ThreadSynchronizationContext.Post(() => OnConnectComplete(e));
                    break;
                case SocketAsyncOperation.Send:
                    this.Service.ThreadSynchronizationContext.Post(() => OnSendComplete(e));
                    break;
                case SocketAsyncOperation.Receive:
                    this.Service.ThreadSynchronizationContext.Post(() => OnReceiveComplete(e));
                    break;
                case SocketAsyncOperation.Disconnect:
                    this.Service.ThreadSynchronizationContext.Post(() => OnDisconnectComplete(e));
                    break;
                default:
                    throw new Exception($"socket error: {e.LastOperation}");
            }
        }

        private void OnConnectComplete(object o)
        {
            if (this.socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;

            if (e.SocketError != SocketError.Success)
            {
                this.OnError((int) e.SocketError);
                return;
            }

            e.RemoteEndPoint = null;

            this.isConnected = true;
            this.StartRecv();
            this.StartSend();
        }

        private void OnDisconnectComplete(object o)
        {
            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;
            this.OnError((int) e.SocketError);
        }

        private void StartRecv()
        {
            while (true)
            {
                try
                {
                    if (this.socket == null)
                    {
                        return;
                    }

                    int size = this.recieveBuffer.ChunkSize - this.recieveBuffer.LastIndex;
                    this.innArgs.SetBuffer(this.recieveBuffer.Last, this.recieveBuffer.LastIndex, size);
                }
                catch (Exception e)
                {
                    Log.Error($"tchannel error: {this.Id}\n{e}");
                    this.OnError(ErrorCore.ERR_TChannelRecvError);
                    return;
                }

                if (this.socket.ReceiveAsync(this.innArgs))
                {
                    return;
                }

                this.OnReceiveComplete(this.innArgs);
            }
        }

        private void OnReceiveComplete(object o)
        {
            this.HandleRecieve(o);

            if (this.socket == null)
            {
                return;
            }

            this.StartRecv();
        }

        public void HandleRecieve(object o)
        {
            if (this.socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;

            if (e.SocketError != SocketError.Success)
            {
                this.OnError((int) e.SocketError);
                return;
            }

            if (e.BytesTransferred == 0)
            {
                this.OnError(ErrorCore.ERR_PeerDisconnect);
                return;
            }

            this.recieveBuffer.LastIndex += e.BytesTransferred;
            if (this.recieveBuffer.LastIndex == this.recieveBuffer.ChunkSize)
            {
                this.recieveBuffer.AddLast();
                this.recieveBuffer.LastIndex = 0;
            }

            // 收到消息回调
            while (true)
            {
                // 这里循环解析消息执行，有可能，执行消息的过程中断开了session
                if (this.socket == null)
                {
                    return;
                }

                try
                {
                    bool ret = this.parser.Parse();
                    if (!ret)
                    {
                        break;
                    }

                    this.OnRead(this.parser.MemoryStream);
                }
                catch (Exception ee)
                {
                    Log.Error($"ip: {this.RemoteAddress} {ee}");
                    this.OnError(ErrorCore.ERR_SocketError);
                    return;
                }
            }
        }

        private void StartSend()
        {
            if (!this.isConnected)
            {
                return;
            }

            if (this.isSending)
            {
                return;
            }

            while (true)
            {
                try
                {
                    if (this.socket == null)
                    {
                        this.isSending = false;
                        return;
                    }

                    // 没有数据需要发送
                    if (this.sendBuffer.Length == 0)
                    {
                        this.isSending = false;
                        return;
                    }

                    this.isSending = true;
                    //获取发送的包的大小
                    int sendSize = this.sendBuffer.ChunkSize - this.sendBuffer.FirstIndex;
                    if (sendSize > this.sendBuffer.Length)
                    {
                        sendSize = (int) this.sendBuffer.Length;
                    }
                    //设置发送的包
                    this.outArgs.SetBuffer(this.sendBuffer.First, this.sendBuffer.FirstIndex, sendSize);

                    if (this.socket.SendAsync(this.outArgs))
                    {
                        return;
                    }

                    this.OnSendComplete(this.outArgs);
                }
                catch (Exception e)
                {
                    throw new Exception($"socket set buffer error: {this.sendBuffer.First.Length}, {this.sendBuffer.FirstIndex}", e);
                }
            }
        }

        private void OnSendComplete(object o)
        {
            HandleSend(o);

            this.isSending = false;

            this.StartSend();
        }

        private void HandleSend(object o)
        {
            if (this.socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;

            if (e.SocketError != SocketError.Success)
            {
                this.OnError((int) e.SocketError);
                return;
            }

            if (e.BytesTransferred == 0)
            {
                this.OnError(ErrorCore.ERR_PeerDisconnect);
                return;
            }
        
            this.sendBuffer.FirstIndex += e.BytesTransferred;
            if (this.sendBuffer.FirstIndex == this.sendBuffer.ChunkSize)
            {
                this.sendBuffer.FirstIndex = 0;
                this.sendBuffer.RemoveFirst();
            }
        }

        public void Send(PomeloPacketType type, MemoryStream stream)
        {
            if (this.IsDisposed)
            {
                throw new Exception("TChannel已经被Dispose, 不能发送消息");
            }
            //构建包头
            PomeloPacketParser.WritePacketSize(packetCache, type, (int) (stream.Length - stream.Position));
            //写入包头
            this.sendBuffer.Write(packetCache, 0, packetCache.Length);
            //写入包体
            this.sendBuffer.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
            if (!this.isSending)
            {
                this.Service.NeedStartSend.Add(this.Id);
            }
        }

        public void Update()
        {
            this.StartSend();
        }

        private void OnRead(MemoryStream memoryStream)
        {
            try
            {
                long channelId = this.Id;
                this.Service.OnRead(channelId, memoryStream);
            }
            catch (Exception e)
            {
                Log.Error($"{this.RemoteAddress} {memoryStream.Length} {e}");
                // 出现任何消息解析异常都要断开Session，防止客户端伪造消息
                this.OnError(ErrorCore.ERR_PacketParserError);
            }
        }

        private void OnError(int error)
        {
            Log.Info($"PChannel OnError: {error} {this.RemoteAddress}");

            long channelId = this.Id;

            this.Service.Remove(channelId);

            this.Service.OnError(channelId, error);
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            Log.Info($"channel dispose: {this.Id} {this.RemoteAddress}");

            long id = this.Id;
            this.Id = 0;
            this.Service.Remove(id);
            this.socket.Close();
            this.outArgs.Dispose();
            this.outArgs = null;
            this.socket = null;
        }
    }
}