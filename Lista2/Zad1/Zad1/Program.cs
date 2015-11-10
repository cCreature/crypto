using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zad1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ciphers = new Ciphertext[20];
            var keys = new KeyContainer[53];


            var result = @"C:\Users\Simon\Desktop\Krypto2\result.txt";
            var file = new StreamWriter(result); //bedziemy wpisywac do file wynik
            var f = new FileReader(@"C:\Users\Simon\Desktop\Krypto2\zad1.txt");
            var message = f.ReadFile(); //string


            //[]->rows []->kolumny
            var path = "";
            for (var i = 0; i < 20; i++)
            {
                path = @"C:\Users\Simon\Desktop\Krypto2\k" + i + ".txt";
                f = new FileReader(path);
                var c0 = f.ReadFile();
                ciphers[i] = new Ciphertext(c0);
            }

            var keyGen = new KeyGenerator();
//////////////////////////////////////////////////////////////////////////////////////////////

            for (var j = 0; j < 52; j++) //iteration through columns
            {
                keys[j] = new KeyContainer();
                foreach (var key in keyGen)
                {
                    var k = Converter.GetBytesFromBinaryString(key);
                    var final = "";
                    var ks = 0;
                    for (var i = 0; i < 20; i++) //lecimy po wszystkich kryptogramach
                    {
                        var cell = ciphers[i].GetByte(j); //musimy zmieniac
                        var x = Converter.GetBytesFromBinaryString(cell);
                        var res = Converter.XoR(k, x);
                        final = final + Encoding.ASCII.GetString(res);
                    }
                    if (Converter.Check(final))
                    {
                        Console.WriteLine("Key: " + key + " :" + final);
                        keys[j].AddKey(key);
                    }
                }
            }


            var decoder = new Decoder(message, keys);
            decoder.Decode();
            Console.ReadKey();
        }
    }
}


