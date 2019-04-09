using FlooringMastery.BLL;
using FlooringMasteryModels;
using FlooringMasteryModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FlooringMastery.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            //execute for our AddOrderWorkflow
            //Instatiate an OrderManager object
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();
            Console.WriteLine("Add an order");
            Console.WriteLine("---------------------");
            Console.Write("Please enter a order date: "); // must be in future 
            DateTime orderDate = ConsoleRead.ReadOrderDate();
            Console.Write("Please enter a Customer Name: "); // cannot be blank and can contain [a-z] [0-9] and comma characters
            string customerName = ConsoleRead.ReadCustomerName(true);
            Console.WriteLine("Please enter a state: "); // check against the new tax file. if state does not exist we cannot sell there
            ConsoleIO.DisplayStates(manager.GetStates());
            string state = Console.ReadLine();
            Console.Write("please enter a Product type: \n \n "); //show a list of available products and pricing info to choose from
            //return list that we are passing into display products method
            ConsoleIO.DisplayProducts(manager.GetProducts());
            string productType = Console.ReadLine();
            Console.Write("please enter Area: "); // the area must be positive decimal, minimum order size is 100 SQ feet
            decimal? area = ConsoleRead.ReadAreaDecimal(true);
            //populate order fields
            Order aOrder = new Order();
            aOrder.CustomerName = customerName;
            aOrder.State = state;
            aOrder.Area = area == null ? 0.00M : area.Value; ;
            aOrder.ProductType = productType;
            aOrder.OrderNumber = 0;
            Console.WriteLine("\n\nAre you sure you want to Add this order? Y/N");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                OrderAddResponse oar = manager.OrderAdd(orderDate, aOrder);
                if (oar.Success)
                {
                    Console.WriteLine("You have added this order to our system");
                    ConsoleIO.DisplayOrder(aOrder, orderDate.ToShortDateString());
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else 
                {
                    Console.Write("Your order was not Added.");
                    Console.WriteLine(oar.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("Your order was not Added. Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
