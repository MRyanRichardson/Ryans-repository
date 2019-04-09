using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class GameFlow
    {
        public void PlayGame()
        {   // display title that is stored in console output
            ConsoleOutput.DisplayTitle();

            //while statement to see if players would like to play another game.
            while (true)
            {
                //get players names
               
                while (true)
                {
                    string Player1 = ConsoleInput.GetPlayerName(1);
                    if (Player1.Length > 0)
                    {
                        break;

                    }
                }
                while (true)
                {
                    string player2 = ConsoleInput.GetPlayerName(2);
                    if (player2.Length > 0)
                    {
                        break;
                    }


                }

                //Make random to decide which player gets to go first
                Random rnd = new Random();

                //Remember that you have to say 3 so that it will pick 2 players
                int currentPlayer = rnd.Next(1, 3);

                
                SetupWorkFlow setup = new SetupWorkFlow();

                // instantiate board object for p1 and p2
                Board b1 = setup.CreateBoard();
                Board b2 = setup.CreateBoard();

                Console.Clear();

                Console.WriteLine("Player 1 please enter your ship locations");
                setup.PlaceShips(b1);

                Console.Clear();
                Console.WriteLine("Player 2 please enter your ship locations");
                setup.PlaceShips(b2);

                //instantiate fireshot response
                FireShotResponse fsr;

                // Start Firing Shots
                while (true)
                {
                    if (currentPlayer == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("  Player 1\n\n");

                        // Display Board and Shot History
                        ConsoleOutput.DisplayBoard(b2);

                        while (true)
                        {
                            fsr = FireShot(b2);
                            if (ProcessShot(fsr))
                            {
                                break;
                            }
                        }
                        currentPlayer = 2;

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("   Player 2\n\n");

                        // Display Board and Shot History
                        ConsoleOutput.DisplayBoard(b1);
                        while (true)
                        {
                            fsr = FireShot(b1);
                            if (ProcessShot(fsr))
                            {
                                break;
                            }
                        }
                        currentPlayer = 1;
                    }

                    if (fsr.ShotStatus == ShotStatus.Victory)
                    {
                        break;
                    }
                }

                Console.WriteLine("Would you like to play again (Y/N)?");
                string again = Console.ReadLine().ToString().ToUpper();
                if (again != "Y")
                {
                    break;
                }



            }


        }
        //fire shots
        private FireShotResponse FireShot(Board b)
        {
            FireShotResponse fsr;
            Coordinate coord;

            //if coordinate is invalid reloop
            while (true)
            {
                Console.WriteLine($"Enter Your Shot:");

                string c = Console.ReadLine();

                SetupWorkFlow swf = new SetupWorkFlow();
                
                //returns coordinate object with XY set as ints
                coord = swf.GetCoordinateXY(c);
                if (coord != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid Coordinate {c}:");
                }

            }

            
            fsr = b.FireShot(coord);

            //returns a fireshot response
            return fsr;

        }
        private bool ProcessShot(FireShotResponse fsr)
        {
            bool validShot = true;

            switch (fsr.ShotStatus)
            {
                case ShotStatus.Hit:
                    ConsoleOutput.DisplayShot("Hit!", ConsoleColor.Red);
                    break;

                case ShotStatus.Duplicate:
                    ConsoleOutput.DisplayShot("Duplicate. Try again.", ConsoleColor.White);
                    validShot = false;
                    break;

                case ShotStatus.Miss:
                    ConsoleOutput.DisplayShot("Miss.", ConsoleColor.Yellow);
                    break;

                case ShotStatus.HitAndSunk:
                    ConsoleOutput.DisplayShot($"Hit and Sunk {fsr.ShipImpacted}!", ConsoleColor.Red);
                    break;

                case ShotStatus.Invalid:
                    ConsoleOutput.DisplayShot("Invalid Coordinates.  Try again.", ConsoleColor.White);
                    validShot = false;
                    break;

                case ShotStatus.Victory:
                    ConsoleOutput.DisplayShot("You Win!", ConsoleColor.Green);
                    break;



                default:
                    break;



            }
            Console.ReadKey();
            // return whether our shot was valid or not
            return validShot;
        }
    }


}
