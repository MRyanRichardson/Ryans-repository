using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class ConsoleInput
    {
        public static int GetNumInput()
        {
            Console.Clear();
            int output;
            string input;

            while (true)
            {
                Console.Write("Please enter a Number");
                input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That was not a valid number! Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
        public static string GetPlayerName(int num)
        {
            string name;
            Console.WriteLine($" Enter Player {num} Name");
            name = Console.ReadLine();
            return name;


        }
    }
}
