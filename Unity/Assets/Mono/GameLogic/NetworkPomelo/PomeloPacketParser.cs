using System;
using System.IO;

namespace ET
{
    public struct PomeloPacket
    {
        public const int PacketSize = 4;
        public const int MinPacketSize = 2;
    }

    public enum PomeloPacketType
    {
        PKG_HANDSHAKE = 1,
        PKG_HANDSHAKE_ACK = 2,
        PKG_HEARTBEAT = 3,
        PKG_DATA = 4,
        PKG_KICK = 5
    }

    public class PomeloPacketParser
    {
        private readonly CircularBuffer buffer;
        private int packetSize;
        private byte[] packetType = new byte[1];
        private ParserState state;
        private readonly byte[] cache = new byte[PomeloPacket.PacketSize];
        public MemoryStream MemoryStream;

        public PomeloPacketParser(CircularBuffer buffer)
        {
            this.buffer = buffer;
        }

        public bool Parse()
        {
            while (true)
            {
                switch (this.state)
                {
                    case ParserState.PacketSize:
                    {
                        if (this.buffer.Length < PomeloPacket.PacketSize)
                        {
                            return false;
                        }
                        //读取包头大小
                        this.buffer.Read(this.cache, 0, PomeloPacket.PacketSize);
                        this.packetSize = (this.cache[1] << 16) + (this.cache[2] << 8) + this.cache[3];
                        if (this.packetSize > ushort.MaxValue * 16 || this.packetSize < 0)
                        {
                            throw new Exception($"recv packet size error, 可能是外网探测端口: {this.packetSize}");
                        }
                        //获取包的类型
                        this.packetType[0] = this.cache[0];
                        this.state = ParserState.PacketBody;
                        break;
                    }
                    case ParserState.PacketBody:
                    {
                        if (this.buffer.Length < this.packetSize)
                        {
                            return false;
                        }
                        //读取包体
                        MemoryStream memoryStream = new MemoryStream(this.packetSize + 1);
                        memoryStream.Write(this.packetType,0,1);
                        this.buffer.Read(memoryStream,  this.packetSize);
                        this.MemoryStream = memoryStream;
                        this.state = ParserState.PacketSize;
                        return true;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static void WritePacketSize(byte[] buffer, PomeloPacketType type, int bodyLength)
        {
            int index = 0;
            buffer[index++] = Convert.ToByte(type);
            buffer[index++] = Convert.ToByte(bodyLength >> 16 & 0xFF);
            buffer[index++] = Convert.ToByte(bodyLength >> 8 & 0xFF);
            buffer[index++] = Convert.ToByte(bodyLength & 0xFF);
        }
    }
}