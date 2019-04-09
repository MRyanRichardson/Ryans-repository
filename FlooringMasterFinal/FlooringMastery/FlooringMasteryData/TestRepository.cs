using FlooringMasteryModels;
using FlooringMasteryModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FlooringMasteryData
{
    public class TestRepository : IOrderRepository
    {   //set type list order
        private static List<Order> _orders;
        /* Create Dictionary to hold file name and list of orders associated with file
         * Example:
         *   Orders_02/20/2019     List<Order>
         *   Orders_10/28/1995     List<Order>
         */
        private static Dictionary<string, List<Order>> dOrders = new Dictionary<string, List<Order>>();
        //constructor sets up test data in static dictionary
        public TestRepository()
        {
            if (_orders == null)
            {
                _orders = new List<Order>() {
                  new Order{
                    OrderNumber = 1,
                    CustomerName = "Ryan",
                    State = "OH",
                    TaxRate = 6.25M,
                    ProductType = "Wood",
                    Area = 100.00M,
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,
                    MaterialCost = 515.00M,
                    LaborCost = 475.00M,
                    Tax = 61.88M,
                    Total = 1051.88M },
               new Order
               {
                   OrderNumber = 2,
                   CustomerName = "Matthew",
                   State = "KY",
                   TaxRate = 6.25M,
                   ProductType = "Carpet",
                   Area = 240.00M,
                   CostPerSquareFoot = 3.15M,
                   LaborCostPerSquareFoot = 2.75M,
                   MaterialCost = 756.00M,
                   LaborCost = 660.00M,
                   Tax = 88.50M,
                   Total = 1504.50M
               } };
                dOrders.Add("10281995", _orders);
                _orders = new List<Order>() {
                  new Order{  OrderNumber = 1,
                    CustomerName = "Sarah",
                    State = "OH",
                    TaxRate = 6.25M,
                    ProductType = "Wood",
                    Area = 100.00M,
                    CostPerSquareFoot = 5.00M,
                    LaborCostPerSquareFoot = 3.00M,
                    MaterialCost = 500.00M,
                    LaborCost = 300.00M,
                    Tax = 50.00M,
                    Total = 850.00M },
              };
                dOrders.Add("02111998", _orders);
            }
        }
        //list of tax information in static state
        public static List<Tax> lTax = new List<Tax>()
            {
            new Tax
                {StateAbbreviation="OH",StateName="Ohio",TaxRate=6.25M},
            new Tax
                {StateAbbreviation="PA",StateName="Pennsylvania",TaxRate=6.75M},
            new Tax
                {StateAbbreviation="MI",StateName="Michigan",TaxRate=5.75M},
            new Tax
                {StateAbbreviation="IN",StateName="Indiana",TaxRate=6.00M}
            };
        //list of product information
        public static List<Product> lProduct = new List<Product>()
            {
                new Product{ ProductType="Carpet",CostPerSquareFoot=2.25M, LaborCostPerSquareFoot=2.10M },
                new Product{ ProductType="Laminate",CostPerSquareFoot=1.75M, LaborCostPerSquareFoot=2.10M},
                new Product{ ProductType="Tile",CostPerSquareFoot=3.50M, LaborCostPerSquareFoot=4.15M },
                new Product{ ProductType="Wood",CostPerSquareFoot=5.15M, LaborCostPerSquareFoot=4.74M }
            };
        public bool DeleteOrder(DateTime orderDate, int orderNumber)
        {
            if (dOrders.ContainsKey(orderDate.ToString("MMddyyyy")))
            {
                string strOrderDate = orderDate.ToString("MMddyyyy");
                List<Order> lOrders = dOrders[strOrderDate];
                var obj = lOrders.FirstOrDefault(l => l.OrderNumber == orderNumber);
                lOrders.Remove(obj);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Order LoadOrder(DateTime orderDate, int orderNumber)
        {
            List<Order> lOrders = LoadOrderByDate(orderDate);
            if (lOrders != null)
            {
                var obj = lOrders.FirstOrDefault(l => l.OrderNumber == orderNumber);
                if (obj != null)
                {
                    //Had to clone because it was changing in UI and in the Memory
                    // Had to disassociate my UI and Memory
                    return (Order)obj.Clone();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public List<Order> LoadOrderByDate(DateTime orderDate)
        {
            string strOrderDate = orderDate.ToString("MMddyyyy");
            if (dOrders.ContainsKey(strOrderDate))
            {
                return dOrders[strOrderDate];
            }
            else { return null; }
        }
        public bool SaveOrder(DateTime orderDate, Order order)
        {
            string strOrderDate = orderDate.ToString("MMddyyyy");
            int nextOrderNumber = 0;
            order.CustomerName = order.CustomerName.Replace(",", "|");
            //if order.orderNumber = 0 then add an order.  Otherwise, we are saving an existing order.
            if (order.OrderNumber == 0)
            {
                //Check if Order File Exists
                List<Order> lOrders = LoadOrderByDate(orderDate);
                if (lOrders != null)
                {
                    nextOrderNumber = lOrders.Max(l => l.OrderNumber) + 1;
                    order.OrderNumber = nextOrderNumber;
                    lOrders.Add(order);
                }
                else
                {
                    order.OrderNumber = 1;
                    lOrders = new List<Order>();
                    lOrders.Add(order);
                    dOrders.Add(strOrderDate, lOrders);
                }
            }
            else
            {
                if (dOrders.ContainsKey(strOrderDate))
                {
                    List<Order> lOrders = dOrders[strOrderDate];
                    var obj = lOrders.FirstOrDefault(l => l.OrderNumber == order.OrderNumber);
                    if (obj != null)
                    {
                        obj.CustomerName = order.CustomerName;
                        obj.State = order.CustomerName;
                        obj.TaxRate = order.Tax;
                        obj.ProductType = order.ProductType;
                        obj.Area = order.Area;
                        obj.LaborCost = order.LaborCost;
                        obj.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                        obj.CostPerSquareFoot = order.CostPerSquareFoot;
                        obj.MaterialCost = order.MaterialCost;
                        obj.Tax = order.Tax;
                        obj.Total = order.Total;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public List<Tax> getTaxes()
        {
            return lTax;
        }
        public List<Product> getProducts()
        {
            return lProduct;
        }
    }
}
