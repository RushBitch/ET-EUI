using System;
using System.Collections;
using System.Collections.Generic;

namespace ET
{
    public class Util
    {
        //Simple type
        private string[] types;
        private Dictionary<string, int> typeMap;

        public Util()
        {
            this.initTypeMap();
            this.types = new string[] { "uInt32", "sInt32", "int32", "uInt64", "sInt64", "float", "double" };
        }

        /// <summary>
        /// Check out the given type. If it is simple, return ture.
        /// </summary>
        /// <returns>
        /// The simple type.
        /// </returns>
        /// <param name='type'>
        /// If set to <c>true</c> type.
        /// </param>
        public bool isSimpleType(string type)
        {
            int length = types.Length;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                if (type == types[i])
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Check out the given type. If the type exist in typeMap, return true.
        /// </summary>
        /// <returns>
        /// The type.
        /// </returns>
        /// <param name='type'>
        /// Type.
        /// </param>
        public int containType(string type)
        {
            int value, returnInt = 2;
            if (this.typeMap.TryGetValue(type, out value))
            {
                returnInt = value;
            }

            return returnInt;
        }

        //Init the typeMap
        private void initTypeMap()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("uInt32", 0);
            dic.Add("sInt32", 0);
            dic.Add("int32", 0);
            dic.Add("double", 1);
            dic.Add("string", 2);
            dic.Add("float", 5);
            dic.Add("message", 2);

            this.typeMap = dic;
        }

        /// <summary>
        /// Reverses the order of bytes in the array
        /// </summary>
        public static void Reverse(byte[] bytes)
        {
            byte temp;
            for (int first = 0, last = bytes.Length - 1; first < last; first++, last--)
            {
                temp = bytes[first];
                bytes[first] = bytes[last];
                bytes[last] = temp;
            }
        }

        public static int BytesToInt(byte[] src, int offset, int length)
        {
            byte[] a = new byte[length];
            int value = 0;
            for (int i = offset; i < length + offset; i++)
            {
                a[i - offset] = src[i];
                value |= ((src[i] & 0xFF) << (i - offset + 1) * 8);
            }

            return value;
        }
    }
}