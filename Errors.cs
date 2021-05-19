using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SecureChat
{
    class Errors
    {
        public static object InvalidOption()
        {
            var a = "0X04";
            Console.WriteLine("[!] Invalid Option ...");
            Thread.Sleep(1000);
            Console.Clear();
            return a;
        }
        public static object InvalidID()
        {
            var generate = 0; // Demo ... //
            Random random = new Random();
            var newid = random.Next(5555555, 999999999);
            for (int currentid = generate; currentid == newid; generate++) // Doesnt Work in 1.0
            {
                Console.WriteLine("Done ! Your New ID is" + generate);
            }
            return newid;
        }
        public static object MessageLimit()
        {
            var a = "0X04";
            Console.WriteLine("This room has extended the message limit, please create new one ! ");
            Thread.Sleep(1500);
            return a;
        }
    }
}
