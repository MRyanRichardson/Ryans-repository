using FlooringMastery.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMasteryModels.Responses;
namespace FlooringMastery.Workflows
{
    public class LookupOrderWorkflow
    {
        public void Execute()
        {
            //execute for our LookupOrderWorkflow
            //Instatiate an OrderManager object
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Lookup an order"); // if file does not exist it will display an error message and return the user to the main menu
            Console.WriteLine("---------------------");
            Console.Write("Please enter a order date: ");//when file exist print out order
            DateTime orderDate = ConsoleRead.ReadDate();
            OrderLookupResponse response = manager.OrderLookupByDate(orderDate);
            if (response.Success)
            {
                ConsoleIO.DisplayOrderList(response.OrderList , orderDate.ToShortDateString());
            }
            else
            {
                Console.WriteLine("No orders found. ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
