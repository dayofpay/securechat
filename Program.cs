using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
namespace SecureChat
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalrooms = 0;
            restart:
            Console.Title = "Secure Chat | 1.0 Beta | V-DEVS.EU";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Generating ID ...");
            Thread.Sleep(1000);
            Random random = new Random();
            var generate = random.Next(5555555, 999999999);
            Console.WriteLine("ID Generated: " + generate);
            Thread.Sleep(1250);
            Console.Clear();
            Console.Write("Please, chose your username: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            var username = Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(" | Welcome, {0} \r\n | ID: {1}", username, generate);
            Console.Title = "Secure Chat | 1.0 Beta | V-DEVS.EU | " + username + " |" + " " + generate;
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Cyan;
        Nachalo:
            string[] rooms = { "Total", "Rooms: " + totalrooms};
            Console.WriteLine("[1] Settings");
            Console.WriteLine("[2] Create Room");
            Console.WriteLine("[3] Join Room");
            Console.WriteLine(" ");
            Console.Write("Option: ");
            var option = Console.ReadLine();
            if (option == "3")
            {
                Console.WriteLine("In next version ...");
                Thread.Sleep(1000);
                Console.Clear();
                goto Nachalo;
            }
            if (option == "2")
            {
                Console.Clear();
                Console.Write("Room Name: ");
                var roomname = Console.ReadLine();
                if (roomname == "")
                {
                    Errors.InvalidOption();
                    goto Nachalo;
                }
                if (roomname ==" ")
                {
                    Errors.InvalidOption();
                    goto Nachalo;
                }
                Console.Clear();
                messagelimit:
                Console.Write("Message Limit: ");
                var msglimit = int.Parse(Console.ReadLine());
                if (msglimit < 1)
                {
                    Console.WriteLine("Message Limit cannot be less than 1");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto messagelimit;
                }
                Console.WriteLine("Room Created : {0} | Room Protected : True | Message Limit : {1}",roomname,msglimit);
                totalrooms++;
                Thread.Sleep(1500);
                Console.Clear();
                for (int i = 1; i <= msglimit; i++)
                {
                    int totalcommands = 0;
                    string[] commands = { "/totalrooms", "/exit", "/help", "/commands" };
                    Console.Write("[>] ");
                    var outcomingchat = Console.ReadLine();
                    var incomingchat = 0;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("{0} : {1}", username, outcomingchat);
                    if (outcomingchat == "/totalrooms")
                    {
                        totalcommands++;
                        Console.WriteLine("[COMMANDS] {0}, there are total {1} rooms !", username, totalrooms);
                    }
                    if (outcomingchat == "/exit")
                    {
                        totalcommands++;
                        Console.Clear();
                        goto Nachalo;
                    }
                    if (outcomingchat == "/help")
                    {
                        totalcommands++;
                        Console.WriteLine("[COMMANDS] {0}, there are total {1} commands, in order to view them type /commands !", username, totalcommands);
                    }
                    if (outcomingchat == "/commands")
                    {
                        foreach (var command in commands)
                        {
                            Console.WriteLine(command.ToString());
                        }
                    }
                    if (i > msglimit)
                    {
                        Errors.MessageLimit();
                        goto Nachalo;
                    }
                }
            }
            if (option == "1")
            {
                Opcii:
                Console.Clear();
                Console.WriteLine("[1] Destroy My ID");
                Console.WriteLine("[2] RE-Generate New ID");
                Console.WriteLine("[3] Change my Username");
                // SOON MORE //
                Console.WriteLine("");
                Console.Write("Option: ");
                var sett = Console.ReadLine();
                if (sett == "3")
                {
                    Console.Clear();
                    goto restart;
                }
                if (sett == "2")
                {
                    Console.Clear();
                    goto Nachalo;
                }
                if (sett == "1")
                {
                    Console.Clear();
                    Console.WriteLine("[!] WARNING: IF YOU DESTROY YOUR ID YOU WILL HAVE TO CREATE YOUR ID&USERNAME AGAIN! DO YOU CONFIRM ?");
                    Console.WriteLine("Y/N");
                    Console.Write("[>] ");
                    var warning = Console.ReadLine();
                    if (warning == "y")
                    {
                        Console.Clear();
                        goto restart;
                    }
                    if (warning == "Y")
                    {
                        Console.Clear();
                        goto restart;
                    }
                    if (warning == "n")
                    {
                        Console.Clear();
                        goto Opcii;
                    }
                    if (warning == "N")
                    {
                        Console.Clear();
                        goto Opcii;
                    }
                    else
                    {
                        Errors.InvalidOption();
                        goto Nachalo;
                    }
                }
            }
            else
            {
                Errors.InvalidOption();
                goto Nachalo;
            }
        }
    }
}
