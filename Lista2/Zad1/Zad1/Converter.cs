using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zad1
{
    public class Converter
    {



        /// <summary>
        ///     Function which is xoring c values with key values
        /// </summary>
        public static byte[] XoR(byte[] c, byte[] key)
        {
        
            var len = Math.Min(c.Length, key.Length);
            var result = new byte[len];

            for (var i = 0; i < len; i++)
                result[i] = (byte)(c[i] ^ key[i]);

            return result;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }



        /// <summary>
        ///     Given an ASCII(string) converts it to binary string
        /// </summary>
        public static string StringToBinary(string data)
        {
            var sb = new StringBuilder();

            foreach (var c in data)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Given an binary string and converts it to normal string
        ///     <summary>
        public static string BinaryToString(string data)
        {
            var byteList = new List<byte>();

            for (var i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static string NumberToBinary(int data)
        {
            return ToBin(data, 8);

        }

        private static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }

        public static Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();


            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public static string BinToString(string x)
        {
           var data = GetBytesFromBinaryString(x);
           var text = Encoding.ASCII.GetString(data);

            return text;

        }

        public static bool Check(string x)
        {
            return Regex.IsMatch(x, "^[a-zA-Z 0-9.,;!()\"-]*$"); //wyrzucilismy ?
        }
    }
}

