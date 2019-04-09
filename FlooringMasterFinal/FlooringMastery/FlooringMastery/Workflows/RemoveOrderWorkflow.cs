using FlooringMastery.BLL;
using FlooringMasteryModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FlooringMastery.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            //execute for our RemoveOrderWorkflow
            //Instatiate an OrderManager object
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Remove an order");
            Console.WriteLine("---------------------");
            Console.Write("Please enter a order date: ");
            DateTime date = ConsoleRead.ReadDate();
            Console.Write("Please enter a order Number: ");
            // if yes remove order if no reprompt
            int orderNumber = ConsoleRead.ReadInt();
            OrderLookupResponse response = manager.OrderLookup(date, orderNumber);
            if (response.Success)
            {
                ConsoleIO.DisplayOrder(response.Order , date.ToShortDateString());
            }
            else
            {
                Console.Write($"The order that you entered was not found. Press any key to return to menu");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Are you sure that you would like to delete this order? Y/N");
            string answer = Console.ReadLine().ToUpper();
            OrderRemoveResponse remove = new OrderRemoveResponse();
            if (answer == "Y")
            {
                remove = manager.RemoveOrder(date, orderNumber);
                if (remove.Success)
                {
                    Console.WriteLine("Your order has been deleted. Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Your order was not deleted. Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("Your order was not deleted. Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
