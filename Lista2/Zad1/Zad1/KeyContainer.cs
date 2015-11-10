using System.Collections.Generic;

namespace Zad1
{
    internal class KeyContainer
    {
        private readonly List<string> keys;

        public int Number()
        {
            return keys.Count;
        }

        public KeyContainer()
        {
            keys = new List<string>();
        }

        public string GetKey(int x)
        {
            return keys[x];
        }

        public void AddKey(string k)
        {
            keys.Add(k);
        }
    }
}
