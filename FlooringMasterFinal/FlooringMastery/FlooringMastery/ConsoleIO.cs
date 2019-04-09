using FlooringMasteryModels;
using System;
using System.Collections.Generic;
namespace FlooringMastery
{
    public class ConsoleIO
    {
        public static void DisplayOrderList(List<Order> orders, string orderDate)
        {
            foreach (Order order in orders)
            {
                DisplayOrder(order, orderDate);
            }
        }
        //Displays our order
        public static void DisplayOrder(Order order, string orderDate)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber} {orderDate} ");
            Console.WriteLine($"\tCustomer Name: {order.CustomerName.Replace("|", ",")}");
            Console.WriteLine($"\tState: {order.State}");
            Console.WriteLine($"\tTax Rate: {order.TaxRate}");
            Console.WriteLine($"\tProduct Type: {order.ProductType}");
            Console.WriteLine($"\tArea: {order.Area}");
            Console.WriteLine($"\tCost Per Square Foot: {order.CostPerSquareFoot}");
            Console.WriteLine($"\tLabor Cost Per Square Foot:{order.LaborCostPerSquareFoot}");
            Console.WriteLine($"\tMaterial Cost: {order.MaterialCost}");
            Console.WriteLine($"\tLabor Cost: {order.LaborCost}");
            Console.WriteLine($"\tTax: {order.Tax}");
            Console.WriteLine($"\tTotal: {order.Total}\n");
        }
        //display products
        public static void DisplayProducts(List<Product> lProd)
        {
            Console.WriteLine("{0 , 10} {1, -5}", "Product", "Cost");
            foreach (Product p in lProd)
            {
                Console.WriteLine("{0 , 10} {1, -5:C} ", p.ProductType, p.CostPerSquareFoot);
            }
        }
        //display state information
        public static void DisplayStates(List<Tax> lTax)
        {
            Console.WriteLine("{0 , 10} {1, -5}", "Abbr", "State");
            foreach (Tax tax in lTax)
            {
                Console.WriteLine("{0 , 10}={1, -5:C} ", tax.StateAbbreviation, tax.StateName);
            }
        }
    }
}
