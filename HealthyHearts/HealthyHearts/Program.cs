using System;


namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            //What is your age ? 50
            //Your maximum heart rate should be 170 beats per minute
            //Your target HR Zone is 85 - 145 beats per minute

            //create 4 types 
            int theirAge;
            int maxHeartRate;
            int minTarget;
            int maxTarget;

            //Prompt for User's Age
            Console.WriteLine("What is your age?");
            string Age = Console.ReadLine();
            int.TryParse(Age, out theirAge);

            //Calculate Max Heart Rate
            maxHeartRate = (220 - theirAge);
            
            //Calcualate Min and Max Target Heart Reate
            minTarget = Convert.ToInt32(Math.Ceiling(maxHeartRate * .5)); //use math ceiling to round up
            maxTarget = Convert.ToInt32(Math.Ceiling(maxHeartRate * .85));//use math ceiling to round up

            //Output Results
            Console.WriteLine("you maximum heartrate is " + maxHeartRate);

            Console.WriteLine("Your target HR Zone is " + minTarget + " - " + maxTarget + " Beats per minute");
            Console.ReadLine();
        }
    }
}
