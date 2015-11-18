using System;

namespace ProgramAes
{
    public static class PassMonitor
    {
        private static ConsoleKeyInfo key;
        private static string pass;


        public static string LoadPassword()
        {
            pass = "";
            key =  default(ConsoleKeyInfo);
            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }

            return pass;
        }
    }
}
