using System;
using System.Text.RegularExpressions;
namespace FlooringMastery
{
    public class ConsoleRead
    {   
        //read valid integer
        public static int ReadInt()
        {
            int returnValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out returnValue))
                {
                    return returnValue;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect order number.");
                    Console.Write("Please enter a order number: ");
                }
            }
        }
        //read valid decimal
        public static decimal ReadDecimal()
        {
            decimal returnValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out returnValue))
                {
                    return returnValue;
                }
                else
                {
                    Console.WriteLine("You have entered a invalid decimal number.");
                    Console.Write("Please enter a valid decimal number: ");
                }
            }
        }
        //read valid date 
        public static DateTime ReadDate()
        {
            DateTime returnValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out returnValue))
                {
                    return returnValue;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect date.");
                    Console.Write("Please enter a order date: ");
                }
            }
        }
        //read valid orderdate and validate that date is in the future
        public static DateTime ReadOrderDate()
        {
            DateTime returnValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out returnValue))
                {
                    if (returnValue < DateTime.Today)
                    {
                        Console.WriteLine("The date must be in the future.");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect date.");
                }
                Console.Write("Please enter a order date: ");
            }
        }
        //read area decimal and validate is greater than 100 SQ feet
        public static decimal ReadAreaDecimal(bool isAdd)
        {
            decimal returnValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out returnValue))
                {
                    if (returnValue < 100)
                    {
                        Console.WriteLine("The minimum order size is 100 SQ FT");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
                else
                {
                    if (input == "" && !isAdd)
                    {
                        return 0.00M;
                    }
                    Console.WriteLine("You have entered an invalid decimal number.");
                }
                Console.Write("Please enter a valid decimal number: ");
            }
        }
        //read customer name and add in bool to allow user to enter blank customer if editing order
        //check for valid customer name format
        public static string ReadCustomerName(bool isAdd)
        {
            while (true)
            {
                string customerName = Console.ReadLine();
                if (CheckCustomerName(customerName) || (customerName.Trim() == "" && !isAdd))
                {
                    return customerName;
                }
                else
                {
                    Console.WriteLine("Invalid customer name. Customer name is allowed to contain [a-z][0-9] \nas well as periods and comma characters and must not be blank.");
                    Console.ReadKey();
                }
                Console.Write("Please enter a Customer Name: ");
            }
        }
        //make sure customer name contains the right characters
        public static bool CheckCustomerName(string customerName)
        {
            if (!Regex.IsMatch(customerName, @"^[a-zA-Z0-9,. ]+$"))
            {
                return false;
            }
            return true;
        }
    }
}