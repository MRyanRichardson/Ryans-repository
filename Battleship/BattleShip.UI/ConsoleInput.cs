using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public static int GetNumberInput()
        {
            Console.Clear();
            int output;
            string input;

            while (true)
            {
                Console.Write("Enter Number: ");
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

        public static String GetPlayerName(int num)
        {
            Console.WriteLine($"Enter Player {num} name:");
            string name = Console.ReadLine();

            return name;
        }
    }
}
