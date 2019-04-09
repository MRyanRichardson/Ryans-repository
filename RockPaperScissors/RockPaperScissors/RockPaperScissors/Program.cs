using System;


namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare types
            int myTies = 0;
            int myWins = 0;
            int theirWins = 0;
            int iRounds;
            int theirPick;
            int iMyPick;

            //while loop to ask user if they would like to play again.
            while (true)
            {  
              
                //prompt user for how many rounds they would like to play.
                Console.WriteLine("How many rounds would you like to play (1-10)?");
                string Rounds = Console.ReadLine();
                int.TryParse(Rounds, out iRounds);
                Console.WriteLine();

                //If number was not between 1 and 10, quit the program.
                if (iRounds > 10 || iRounds < 1)
                {
                    Console.WriteLine("Number picked was outside the given range (1-10)");
                    Console.ReadLine();
                    break;
                }


                //Loop through number of rounds that the user has picked to play.
                for (int i = 0; i < iRounds; i++)
                {  
                    Console.WriteLine("Would you like to choose 1=Rock, 2=Paper or 3=Scissors?");
              
                    //while loop to make sure that user has entered a number 1,2,3
                    while (true)
                    {
                        string myPick = Console.ReadLine();
                        int.TryParse(myPick, out iMyPick);
                        if (iMyPick == 1 || iMyPick == 2 || iMyPick == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("please enter 1, 2, or 3.");
                        }
                    }

                    // Generate a random pick for the computer.
                    // the Random.Next(1,4) call will generate a number between 1 and 3
                    Random r = new Random();
                    theirPick = r.Next(1, 4);

                    // Check for Tie
                    if (iMyPick == theirPick)
                    {
                        myTies++;
                        Console.WriteLine("Tie\n");
                    }
                    // Check if I won.
                    // My Pick      Their Pick
                    // =======================
                    //  Rock        Scissors
                    //  Paper       Rock
                    //  Scissors    Paper
                    //========================
                    else if ((iMyPick == 1 && theirPick == 3) ||
                            (iMyPick == 2 && theirPick == 1) ||
                            (iMyPick == 3 && theirPick == 2))
                    {
                        Console.WriteLine("User Win\n");
                        myWins++;
                    }
                    // Otherwise, computer won.
                    else  
                    {
                        theirWins++;
                        Console.WriteLine("Computer Win\n");
                    }


                }
                // Output Overall winner
                if (theirWins > myWins)
                {
                  
                    Console.WriteLine("They won!");
                }
                else if (myWins > theirWins)
                {
                  
                    Console.WriteLine("You won!");
                }
                else
                {
                   
                    Console.WriteLine("You tied!");
                }
                //outputs the results at end of game.
                Console.WriteLine();
                Console.WriteLine("They won " + theirWins + " times");
                Console.WriteLine("You won " + myWins + " times");
                Console.WriteLine("You tied " + myTies + " times");
                string playAgain;


                // This loop requires them to enter either a Y or N.
                while (true)
                {
                    Console.WriteLine("would you like to play again (Y)es or (N)o?");

                    playAgain = Console.ReadLine();
                    //Convert to upper converts the input to all uppercase
                    playAgain = playAgain.ToUpper();


                    if (playAgain == "Y")
                    {
                        break;
                    }
                    else if (playAgain == "N")
                    {
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please pick 'Y' or 'N'");
                    }
                }

                // breaks out of main loop and Ends game.
                if (playAgain == "N")
                { 
                    break;
                }

            }
        }
    }
}
