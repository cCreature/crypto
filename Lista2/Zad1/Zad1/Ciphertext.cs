using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    internal class Ciphertext
    {
        private readonly string[] _cipher;

        public Ciphertext(string[] c)
        {
            _cipher = c;
        }

        public string GetByte(int x)
        {

            return _cipher[x];
        }
    

}
}
