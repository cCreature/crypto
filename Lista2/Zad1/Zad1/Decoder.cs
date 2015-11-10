using System;
using System.Text;

namespace Zad1
{
    internal class Decoder
    {
        private readonly KeyContainer[] _keys;
        private readonly string[] _message;

        public Decoder(string[] message, KeyContainer[] keys) //nasza wiadomosc do odszyfrowania, i klucze od 0 do 52
        {
            _keys = keys;
            _message = message;
        }


        public void Decode()
        {
            Console.WriteLine();
            for (var i = 0; i < 52; i++)
            {
                Console.WriteLine();
                if (_keys[i].Number() > 0)
                {
                    var number = _keys[i].Number();
                    var bajt = Converter.GetBytesFromBinaryString(_message[i]);
                    for (var j = 0; j < _keys[i].Number(); j++)
                    {
                        var key = Converter.GetBytesFromBinaryString(_keys[i].GetKey(j));
                        var xor = Converter.XoR(key, bajt);
                        var result = Encoding.ASCII.GetString(xor);

                        Console.Write(result + " ");
                    }
                }
            }
        }
    }
}
