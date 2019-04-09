using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;

using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameFlow
    {
        public void PlayGame()
        {
            
            //Display Splash Screen
            ConsoleOutput.DisplayTitle();
           

            //Get Player Names
            string playerName1 = ConsoleInput.GetPlayerName(1);
            string playerName2 = ConsoleInput.GetPlayerName(2);

            //Which Player goes first?
            Random rnd = new Random();
            int currentPlayer = rnd.Next(1, 3);

            //Place Players Ships
            SetupWorkFlow setup = new SetupWorkFlow();

           
            Board b1 = setup.CreateBoard();
            Board b2 = setup.CreateBoard();




            setup.PlaceShips(b1);




            //setup.PlaceShips(b2);



            // Start Firing Shots

            //while (true)
            //{
            //    FireShotResponse f;

                

            //    f = b1.FireShot(new Coordinate(1, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(2, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(3, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();
            //    f = b1.FireShot(new Coordinate(4, 1));

            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(5, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(6, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(7, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(8, 1));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(1, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(2, 2));
            //    ProcessShot(f);
            //    ConsoleOutput.DisplayBoard(b1);
            //    Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(3, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(4, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(5, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(6, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(7, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(8, 2));
            //    ProcessShot(f);
            //    //ConsoleOutput.DisplayBoard(b1);
            //    //Console.ReadKey();

            //    f = b1.FireShot(new Coordinate(9, 2));
            //    ProcessShot(f);


            //    break;

            //}






         


           


            //Board b1 = new Board();
            //Board b2 = new Board();
                       


            PlaceShipRequest req = new PlaceShipRequest();


            Coordinate coord1 = new Coordinate(2, 1);

            req.Direction = ShipDirection.Right;
            req.ShipType = BLL.Ships.ShipType.Carrier;
            req.Coordinate = coord1;

            b1.PlaceShip(req);

            req.Direction = ShipDirection.Down;
            req.ShipType = BLL.Ships.ShipType.Battleship;
            req.Coordinate = coord1;
            Coordinate coord2 = new Coordinate(2, 1);

            //do
            //{
            //    guess = ConsoleInput.GetGuessFromUser();
            //    result = _manager.ProcessGuess(guess);
            //    ConsoleOutput.DisplayGuessMessage(result);
            //} while (result != GuessResult.Victory);
        }


        private FireShotResponse FireShot(Board b)
        {
            FireShotResponse fsr=null;
            Coordinate coord;
            while (true)
            {
                Console.WriteLine($"Enter Your Shot:");

                string c = Console.ReadLine();

                SetupWorkFlow swf = new SetupWorkFlow();

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

            return fsr;

        }

        private void ProcessShot(FireShotResponse fsr)
        {

           
            switch (fsr.ShotStatus)
            {
                case ShotStatus.Hit:
                    ConsoleOutput.DisplayShot("Hit!", ConsoleColor.Red);
                    break;

                case ShotStatus.Duplicate:
                    ConsoleOutput.DisplayShot("Duplicate. Try again.", ConsoleColor.White);
                    break;

                case ShotStatus.Miss:
                    ConsoleOutput.DisplayShot("Miss.", ConsoleColor.Yellow);
                    break;

                case ShotStatus.HitAndSunk:
                    ConsoleOutput.DisplayShot($"Hit and Sunk {fsr.ShipImpacted}!", ConsoleColor.Red);
                    break;

                case ShotStatus.Invalid:
                    ConsoleOutput.DisplayShot("Invalid Coordinates.  Try again.", ConsoleColor.White);
                    break;

                case ShotStatus.Victory:
                    ConsoleOutput.DisplayShot("You Win!", ConsoleColor.Green);
                    break;



                default:
                    break;



            }
            Console.ReadKey();
        }
        private void CreateGameManagerInstance()
        {
            //_manager = new GameManager();
            //_manager.Start();
        }
    }
}
