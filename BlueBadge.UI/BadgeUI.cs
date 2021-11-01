using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBadge.UI
{
    public class BadgeUI
    {
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "Welcome to Off the Poll\n" +
                        "****************************************************************\n\n" +
                        "1. Login\n" +
                        "2. Register\n" +
                        "5. Exit"
                    );
                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-3");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void Login()//I think this needs to be an async call from the research (same for Register)
        {

        }

        private void Register()
        {

        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            //Change text color
            Console.ForegroundColor = color;
            //text
            Console.Write(message);
            //reset color
            Console.ResetColor();
        }
    }
}
