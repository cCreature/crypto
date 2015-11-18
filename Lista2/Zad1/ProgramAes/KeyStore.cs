using System.IO;

namespace ProgramAes
{
    internal class KeyStore
    {
        private static readonly string _password = "123abc123";
        private readonly string _path;

        public KeyStore(string path)
        {
            _path = path;
        }

        public string GetKey(int id)
        {
            if (!File.Exists(_path))
            {
                return null;
            }
            var keys = File.ReadAllLines(_path);
            if (id < 0 || id > keys.Length - 1)
                return "No key available for given Id!";

            return keys[id];
        }

        public bool ConfirmPassword(string pass)
        {
            return _password.Equals(pass);
        }
    }
}
