using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;


/*
Create a setup workflow object which creates a board instance for the game workflow 
with ships populated by the user.Each player should be prompted to place their 
ships on their board by giving a starting coordinate and a direction.
Clear the screen when a player is finished so the other player can't cheat!
*/


namespace BattleShip.UI
{

    public enum alpha
    {
        A, B, C, D, E, F, G, H, I, J
    }
    class SetupWorkFlow
    {
        public Board CreateBoard()
        {
            Board b = new Board();
            return b;
        }


        public bool CheckCoordinates(string coordinate)
        {
            return true;
        }


        public bool PlaceShips(Board b1)
        {
            PlaceShipRequest psr = new PlaceShipRequest();
            Coordinate coord;

            for (int i = 0; i < 5; i++)
            {
                string shipType = Enum.GetName(typeof(ShipType), i);

                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine($"Enter Starting Coordinate for {shipType}:");

                        string c = Console.ReadLine();

                        coord = GetCoordinateXY(c);
                        if (coord != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid Coordiate {c}:");
                        }

                    }


                    ShipDirection dir;
                    while (true)
                    {
                        Console.WriteLine("Enter Direction:");
                        string d = Console.ReadLine();

                        if (Enum.IsDefined(typeof(ShipDirection), d))
                        {
                            dir = (ShipDirection)Enum.Parse(typeof(ShipDirection), d);
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid Direction:");
                        }

                    }


                    // Populate properties of PlaceShipRequest (psr) object




                    psr.Coordinate = coord;
                    psr.ShipType = (ShipType)i;
                    psr.Direction = dir;

                    var response = b1.PlaceShip(psr);
                    if (response == BLL.Responses.ShipPlacement.Ok)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error - {response}");

                    }
                }



            }

            return true;

        }

        public  Coordinate GetCoordinateXY(string sCoord)
        {
            Coordinate c;
            if (sCoord.Length < 2)
            {
                c = null;
                return c;
            }


            // Grab 1st character
            string s1 = sCoord.Substring(0, 1).ToUpper();
            // Grab rest of characters
            string s2 = sCoord.Substring(1, sCoord.Length - 1);


            int xCoord = 0;
            int yCoord = 0;



            switch (s1)
            {
                case "A":
                    xCoord = 1;
                    break;
                case "B":
                    xCoord = 2;
                    break;
                case "C":
                    xCoord = 3;
                    break;
                case "D":
                    xCoord = 4;
                    break;
                case "E":
                    xCoord = 5;
                    break;
                case "F":
                    xCoord = 6;
                    break;
                case "G":
                    xCoord = 7;
                    break;
                case "H":
                    xCoord = 8;
                    break;
                case "I":
                    xCoord = 9;
                    break;
                case "J":
                    xCoord = 10;
                    break;

                default:
                    xCoord = 0;
                    break;

            }

            //Check if s1 is in Enum alpha
            //if (Enum.IsDefined(typeof(alpha), s1))
            //{
            //    yCoord = (int)Enum.Parse(typeof(alpha), s1) + 1;
            //}

            //Check if s2 is a valid integer
            int.TryParse(s2, out xCoord);

            if (xCoord == 0 || yCoord == 0)
            {
                c = null;
            }
            else
            {
                c = new Coordinate(xCoord, yCoord);
            }
            return c;
        }


    }


}
