using System.Collections.Generic;

namespace Zad1
{
    internal class KeyGenerator
    {
        public IEnumerator<string> GetEnumerator()
        {
            for (var i = 0; i < 256; i++)
            {
                yield return Converter.NumberToBinary(i);
            }
        }
    }
}
