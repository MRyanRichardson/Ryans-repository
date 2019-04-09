using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class SetupWorkFlow

    {   //create board
        public Board CreateBoard()
        {
            Board b = new Board();
            return b;

        }
        public bool PlaceShips(Board b1)
        {
            //create place ship request object
            PlaceShipRequest psr = new PlaceShipRequest();

            //setting the shiptype, direction and coordinate properties
            ShipDirection sd = new ShipDirection();


            //create coordinate object and pass in paremeters           
            Coordinate coord;

            for (int i = 0; i < 5; i++)
            {
                //looping through the shiptype enum
                string shipType = Enum.GetName(typeof(ShipType), i);

                // loops until we properly enter all 3 properties of PSR
                while (true)
                {
                    //while to make sure user enters a valid coordinate
                    while (true)
                    {

                        Console.WriteLine($"Where would you like your {shipType} to be placed?");
                        string c = Console.ReadLine();

                        //see if their input is a valid coordinate
                        coord = GetCoordinateXY(c);
                        if (coord == null)
                        {
                            Console.WriteLine("Invalid Coordinate");
                        }

                        else
                        {

                            break;
                        }

                    }

                    //make sure user enters a valid direction
                    while (true)
                    {
                        Console.WriteLine("How would you like to place your ship? Up, Down, Left or Right");
                        string direction = Console.ReadLine();


                        bool validDirection = true;
                        switch (direction)
                        {
                            case "Up":
                                sd = ShipDirection.Up;
                                break;
                            case "Down":
                                sd = ShipDirection.Down;
                                break;
                            case "Left":
                                sd = ShipDirection.Left;
                                break;
                            case "Right":
                                sd = ShipDirection.Right;
                                break;

                            default:
                                validDirection = false;
                                break;

                        }

                        if (validDirection)
                        {
                            break;
                        }
                    }


                    // set 3 properties of psr object
                    //looping through to get shiptypes for i
                    psr.ShipType = (ShipType)i;
                    psr.Coordinate = coord;
                    psr.Direction = sd;

                    //if place ship = ok
                    ShipPlacement sp = b1.PlaceShip(psr);

                    if (sp == BLL.Responses.ShipPlacement.Ok)
                    {
                        break;

                    }
                    else
                    {// write out what the problem is, overlapping or not enough room.
                        Console.WriteLine(sp);
                        Console.ReadKey();
                    }


                }
            }


            return true;
        }
        //pass in user input to sCoord
        public Coordinate GetCoordinateXY(string sCoord)
        {
            Coordinate c;
            if (sCoord.Length < 2)
            {
                c = null;
                return c;
            }
            // grab the first character

            string S1 = sCoord.Substring(0, 1);
            //grab the second character
            //when we enter 1 in substring it will go over to the second character get length and minus 1. (because index is starting from zero)
            string s2 = sCoord.Substring(1, sCoord.Length - 1);

            // create types for  X and Y coordinates
            int xCoord = 0;
            int yCoord = 0;


            //converting alpha enum to y coordinate
            switch (S1)
            {
                case "A":
                    yCoord = 1;
                    break;
                case "B":
                    yCoord = 2;
                    break;
                case "C":
                    yCoord = 3;
                    break;
                case "D":
                    yCoord = 4;
                    break;
                case "E":
                    yCoord = 5;
                    break;
                case "F":
                    yCoord = 6;
                    break;
                case "G":
                    yCoord = 7;
                    break;
                case "H":
                    yCoord = 8;
                    break;
                case "I":
                    yCoord = 9;
                    break;
                case "J":
                    yCoord = 10;
                    break;

                //if none of the above the automatically put y coord to zero
                default:
                    yCoord = 0;

                    break;


            }

            //get x coordinate 
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
