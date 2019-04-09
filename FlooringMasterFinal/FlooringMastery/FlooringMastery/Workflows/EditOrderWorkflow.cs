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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            //execute for our EditOrderWorkflow
            //Instatiate an OrderManager object
            OrderManager manager = OrderManagerFactory.Create();
            Order eOrder;
            Console.Clear();
            Console.WriteLine("Edit and order");
            Console.WriteLine("---------------------");
            Console.Write("Please enter a order date: ");
            DateTime orderDate = ConsoleRead.ReadDate();
            Console.Write("Please enter a order Number: ");
            int orderNumber = ConsoleRead.ReadInt();
            if (orderNumber > 0)
            {
                //if input is something new, automatically change the file
                //only certain data can be changed, customername, state, product type and the area
                OrderLookupResponse response = manager.OrderLookup(orderDate, orderNumber);
                if (response.Success)
                {
                    ConsoleIO.DisplayOrder(response.Order, orderDate.ToShortDateString());
                    eOrder = response.Order;
                }
                else
                {
                    Console.WriteLine("An error occured: ");
                    Console.WriteLine(response.Message);
                    return;
                }
                Console.WriteLine("Please update the following information. (Press Enter to leave unchanged) ");
                Console.Write("Please enter a customer's name :");
                string custName = ConsoleRead.ReadCustomerName(false);
                Console.WriteLine("Please enter a customer's state: ");
                ConsoleIO.DisplayStates(manager.GetStates());
                string custState = Console.ReadLine();
                Console.WriteLine("Please enter a product type: ");
                //return list that we are passing into display products method
                ConsoleIO.DisplayProducts(manager.GetProducts());
                string productType = Console.ReadLine();
                Console.Write("please enter Area: "); // the area must be positive decimal, minimum order size is 100 SQ feet
                decimal area = ConsoleRead.ReadAreaDecimal(false);
                eOrder.CustomerName = custName == "" ? eOrder.CustomerName : custName;
                eOrder.State = custState == "" ? eOrder.State : custState;
                eOrder.ProductType = productType == "" ? eOrder.ProductType : productType;
                eOrder.Area = area == 0.00M ? eOrder.Area : area;
                Console.WriteLine("\n\nAre you sure you want to update this order? Y/N");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    OrderEditResponse oer = manager.OrderEdit(orderDate, eOrder);
                    if (oer.Success)
                    {
                        Console.WriteLine("\nYou have updated this order in our system");
                        ConsoleIO.DisplayOrder(eOrder, orderDate.ToShortDateString());
                        Console.WriteLine("Press any key to continue\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nYour order was not updated. Press any key to continue");
                        Console.WriteLine(oer.Message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("Your order was not updated. Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}