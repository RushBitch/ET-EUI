using System.Text;

namespace ET
{
    public class PomeloMessageAttribute: BaseAttribute
    {
        private readonly string routeString;

        public PomeloMessageAttribute(string routeString)
        {
            this.routeString = routeString;
        }

        public int GetRouteCode()
        {
            return BytesToInt(GetRouteByte(), 0, GetRouteByte().Length);
        }

        public byte[] GetRouteByte()
        {
            return Encoding.UTF8.GetBytes(this.routeString);
        }
        
        public string GetRouteStr()
        {
            return this.routeString;
        }

        private int BytesToInt(byte[] src, int offset, int length)
        {
            int value = 0;
            for (int i = offset; i < length - offset; i++)
            {
                value |= ((src[i] & 0xFF) << (i + 1) * 8);
            }

            return value;
        }
    }
}