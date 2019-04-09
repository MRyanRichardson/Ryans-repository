using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************************************");
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("         Welcome to Battleship!       ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");
            Console.Write("*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("           By Ryan Richardson         ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*");
            Console.WriteLine("****************************************\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
      }

        public static void DisplayShot(string message, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayBoard(Board b)
        {

         

                //header
                Console.WriteLine();
                Console.WriteLine("    A B C D E F G H I J ");
                Console.WriteLine("   _____________________");
                Console.WriteLine("  |                     |");

                //loop to start first row 

                for (int j = 1; j <= 10; j++)
                {
                    if (j == 10)
                    {
                        Console.Write(j.ToString() + "| ");
                    }
                    else
                    {
                        Console.Write(j.ToString() + " | ");
                    }


                    //Console.Write("A | ");

                    //foreach (int value in Enum.GetValues(typeof(alpha)))'
                    for (int i = 1; i <= 10; i++)
                    {
                        switch (b.CheckCoordinate(new Coordinate(j, i)))
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("H ");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("M ");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("O ");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;



                        }
                        //Console.Write("O ");

                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine("  |_____________________|");
            }
        




    }
}
