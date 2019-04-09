using System;


namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int iTot = 0;
            //Declare Arrays
            int[] array1 = new[] { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] array2 = new[] {999, -60, -77, 14, 160, 301 };
            int[] array3 = new[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130,
                                    140, 150, 160, 170, 180, 190, 200, -99 };




            //Call AddArray method;
            iTot = AddArray(array1);
            Console.WriteLine("#1 Array Sum: " + iTot);

            iTot = AddArray(array2);
            Console.WriteLine("#2 Array Sum: " + iTot);

            iTot = AddArray(array3);
            Console.WriteLine("#3 Array Sum: " + iTot);

            Console.ReadLine();
        }

        //method AddArray.  Takes in array as parameter and totals all elements. Returns Sum of arrays elements.
        public static int AddArray(int[] ary)
        {
            int iTotal = 0;
            for (int i = 0; i < ary.Length; i++)
            {
                iTotal = iTotal + ary[i];  //Total all elements
            }
            return iTotal;
        }




      
    }
}
