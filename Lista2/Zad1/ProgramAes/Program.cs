using System;

namespace ProgramAes
{
    internal class Program
    {

        //Aes Encrypter/Decrypter
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter path to key store");
            var path = @"C:\Users\jake\Desktop\keys.txt";
            var keyStore = new KeyStore(path);
            ReadPass(keyStore);
            //*****************************************************************************//

            Console.WriteLine("Welcome! Please choose between E(Encryption) or D(Decryption)");
            var objective = Console.ReadLine();

            Task:
            if (!objective.Equals("D") && !objective.Equals("E"))
            {
                Console.WriteLine("Please enter a correct task.");
                objective = Console.ReadLine();
                goto Task;
            }

            //********************************WeGotObjective**************************************//
            var cipher = Manufacture(objective, keyStore);
            Console.WriteLine("Ciphertext: {0}", cipher);

            Console.ReadKey();
        }


        public static string Manufacture(string obj, KeyStore ks)
        {
            Console.WriteLine("Please Entera a message to be manufactured: ");
            var message = Console.ReadLine();
            Console.WriteLine("Please enter an ID for a SECRET password: ");
            var id = int.Parse(Console.ReadLine());

            var key = ks.GetKey(id);

            if (obj.Equals("E"))
            {
                return new Encryption().EncryptText(message, key);
            }
            return new Decryption().DecryptText(message, key);
        }


        private static void ReadPass(KeyStore ks)
        {
            START:
            Console.WriteLine("Enter a password!");

            var pass = PassMonitor.LoadPassword();

            if (ks.ConfirmPassword(pass))

                Console.WriteLine("\nCorrect password.");
            else
            {
                Console.WriteLine("\n Password incorrect! Try again.");
                goto START;
            }
        }
    }
}
