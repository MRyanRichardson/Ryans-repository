using System;


namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaration section
            int coonHound;
            int beagle;
            int borderCollie;
            int bassetHound;
            int greatDane;
            int total = 100;  //initialize total to 100 to represent 100%
            string dogsName;

            //Create Random object
            Random r = new Random();

            //prompt user for dogs name
            Console.Write("What is your dogs name? ");
            dogsName =  Console.ReadLine();
            Console.WriteLine("\nWell then, I have this highly reliable report on " +dogsName+ "'s prestigious background right here.\n");
            Console.WriteLine( dogsName + " is:\n");

            // calclate percentages based on random generator
            coonHound = r.Next(total);
            total = total - coonHound; //Subtract amount from total to determine the next Random call's max.
            Console.WriteLine(coonHound + "% coonhound");

            beagle = r.Next(total);
            total = total - beagle; //Subtract amount from total to determine the next Random call's max.
            Console.WriteLine(beagle + "% Beagle");

            borderCollie = r.Next(total);
            total = total - borderCollie; //Subtract amount from total to determine the next Random call's max.
            Console.WriteLine( borderCollie + "% Border Collie");

            bassetHound = r.Next(total);
            total = total - bassetHound; //Subtract amount from total to determine the next Random call's max.
            Console.WriteLine(bassetHound + "% Basset Hound");

            // Assign remainder of Total to Great Dane category
            greatDane = total; 
            Console.WriteLine(greatDane + "% Great Dane");


            Console.WriteLine("\nWow, that's QUITE the dog!");
            Console.ReadLine();
        }
    }
}
