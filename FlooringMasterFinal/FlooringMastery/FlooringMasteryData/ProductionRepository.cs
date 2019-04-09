using FlooringMasteryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using FlooringMasteryModels.Interfaces;
namespace FlooringMasteryData
{
    public class ProductionRepository : IOrderRepository
    {
        public string _filePath { get; set; }  /*Holds the path to the data files*/
        private List<Tax> listTax { get; set; } /* Holds list of tax info */
        private List<Product> listProduct { get; set; } /* Holds list of product info */
        private List<Order> _orders;   /* Holds list of product info */
        /* Create Dictionary to hold file name and list of orders associated with file
         * Example:
         *   Orders_02/20/2019     List<Order>
         *   Orders_10/28/1995     List<Order>
         */
        private Dictionary<string, List<Order>> dOrders = new Dictionary<string, List<Order>>();
        public ProductionRepository()
        {
            _filePath = ConfigurationManager.AppSettings.Get("FileFolder");  /*retrieve filepath from app.config*/
            string[] aryFiles = GetFileNames(); /* read file names from filepath */
            PopulateData(aryFiles); /* write 'order' data to dictionary and write tax and product info to Lists*/
        }
        public List<Product> getProducts()
        {
            // List<Product>
            return listProduct;
        }
        public List<Tax> getTaxes()
        {
            //List<Tax>
            return listTax;
        }
        // used by add edit and remove
        // Load 1 order based on Order Date and Order Number
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
        // This method loads all orders associated with a particular date and returns as List<Order>
        public List<Order> LoadOrderByDate(DateTime orderDate)
        {
            string strOrderDate = orderDate.ToString("MMddyyyy");
            var orderKey = dOrders.Keys.FirstOrDefault(k => k.Contains(strOrderDate));
            if (orderKey != null)
            {
                return dOrders[orderKey];
            }
            else
            {
                return null;
            }
        }
        //save order is for editing and adding records
        public bool SaveOrder(DateTime orderDate, Order order)
        {
            string strOrderDate = orderDate.ToString("MMddyyyy");
            string fName = $"Orders_{strOrderDate}.txt";
            List<Order> _orders = new List<Order>();
            int nextOrderNumber = 0;
            //need to be using for streamwriter
            //Write Header
            //keys = filename
            //
            //If OrderNumber is 0 then we are adding a new order
            if (order.OrderNumber == 0)
            {
                //Check if Order File Exists
                List<Order> lOrders = LoadOrderByDate(orderDate);
                // Write new order to an existing file.
                if (lOrders != null)
                {
                    // 
                    // nextOrderNumber is 1 more than the max order number found for the file
                    nextOrderNumber = lOrders.Max(l => l.OrderNumber) + 1;
                    order.OrderNumber = nextOrderNumber;
                    lOrders.Add(order);
                    // Create streamwriter object to write  order
                    StreamWriter sw = new StreamWriter(_filePath + fName, append: true);
                    //writes the header
                    sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate}," +
                                $"{order.ProductType},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost}," +
                                $"{order.LaborCost},{order.Tax},{order.Total}");
                    sw.Close();
                }
                // Write new order including new file name.
                else
                {
                    nextOrderNumber = 1;
                    order.OrderNumber = nextOrderNumber;
                    StreamWriter sw = new StreamWriter(_filePath + fName, append: true);
                    sw.WriteLine($"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State},{order.TaxRate}," +
                                $"{order.ProductType},{order.Area},{order.CostPerSquareFoot},{order.LaborCostPerSquareFoot},{order.MaterialCost}," +
                                $"{order.LaborCost},{order.Tax},{order.Total}");
                    sw.Close();
                    lOrders = new List<Order>();
                    lOrders.Add(order);
                    dOrders.Add(strOrderDate, lOrders);
                }
            }
            else
            {
                //If we are here, we are editing an existing file.
                //Find Order File 
                List<Order> lOrders = LoadOrderByDate(orderDate);
                StreamWriter sw = new StreamWriter(_filePath + fName);
                sw.WriteLine($"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (Order ord in lOrders)
                {
                    if (ord.OrderNumber == order.OrderNumber)
                    {
                        // when order is found, update the existing order.
                        ord.CustomerName = order.CustomerName.Replace(",", "|");
                        ord.State = order.State;
                        ord.TaxRate = order.TaxRate;
                        ord.ProductType = order.ProductType;
                        ord.Area = order.Area;
                        ord.CostPerSquareFoot = order.CostPerSquareFoot;
                        ord.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                        ord.MaterialCost = order.MaterialCost;
                        ord.LaborCost = order.LaborCost;
                        ord.Tax = order.Tax;
                        ord.Total = order.Total;
                    }
                    // write the order
                    sw.WriteLine($"{ord.OrderNumber},{ord.CustomerName},{ord.State},{ord.TaxRate}," +
                        $"{ord.ProductType},{ord.Area},{ord.CostPerSquareFoot},{ord.LaborCostPerSquareFoot},{ord.MaterialCost}," +
                        $"{ord.LaborCost},{ord.Tax},{ord.Total}");
                }
                //have to close streamwriter or it will not write data
                sw.Close();
                return true;
            };
            return true;
        }
        //gets all file names out of data folder that begin with orders_ and ends with .txt ("Orders_*.txt")
        private string[] GetFileNames()
        {
            string[] fileNames = Directory.GetFiles(_filePath, "Orders_*.txt");
            return fileNames;
        }
        //pass in all filenames from data folder
        //reads all files and info and grabs the orders that are contained in file
        private void PopulateData(string[] fileNames)
        {
            foreach (string fName in fileNames)
            {
                List<Order> _orders = new List<Order>();
                using (StreamReader sr = new StreamReader(fName))
                {
                    sr.ReadLine();// header line
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] s = line.Split(',');
                        Order order = new Order();
                        order.OrderNumber = Convert.ToInt32(s[0]);
                        order.CustomerName = s[1];
                        order.State = s[2];
                        order.TaxRate = Convert.ToDecimal(s[3]);
                        order.ProductType = s[4];
                        order.Area = Convert.ToDecimal(s[5]);
                        order.CostPerSquareFoot = Convert.ToDecimal(s[6]);
                        order.LaborCostPerSquareFoot = Convert.ToDecimal(s[7]);
                        order.MaterialCost = Convert.ToDecimal(s[8]);
                        order.LaborCost = Convert.ToDecimal(s[9]);
                        order.Tax = Convert.ToDecimal(s[10]);
                        order.Total = Convert.ToDecimal(s[11]);
                        _orders.Add(order);
                    }
                }
                dOrders.Add(fName, _orders);
            }
            //Get Tax Data
            listTax = new List<Tax>();
            string taxFileName = ConfigurationManager.AppSettings.Get("taxFileName");
            using (StreamReader sr = new StreamReader(_filePath + taxFileName))
            {
                sr.ReadLine();// header line
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split(',');
                    Tax tax = new Tax();
                    tax.StateAbbreviation = s[0];
                    tax.StateName = s[1];
                    tax.TaxRate = Convert.ToDecimal(s[2]);
                    listTax.Add(tax);
                }
            }
            //Get Product Data
            listProduct = new List<Product>();
            string productFileName = ConfigurationManager.AppSettings.Get("productFileName");
            using (StreamReader sr = new StreamReader(_filePath + productFileName))
            {
                sr.ReadLine();// header line
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split(',');
                    Product product = new Product();
                    product.ProductType = s[0];
                    product.CostPerSquareFoot = Convert.ToDecimal(s[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(s[2]);
                    listProduct.Add(product);
                }
            }
        }
        public bool DeleteOrder(DateTime orderDate, int orderNumber)
        {
            string strOrderDate = orderDate.ToString("MMddyyyy");
            List<Order> lOrders = LoadOrderByDate(orderDate);
            if (lOrders != null)
            {
                string fName = $"Orders_{strOrderDate}.txt";
                StreamWriter sw = new StreamWriter(_filePath + fName);
                sw.WriteLine($"OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (Order ord in lOrders)
                {
                    if (ord.OrderNumber != orderNumber)
                    {// Only write orders to file that do not match order.
                        sw.WriteLine($"{ord.OrderNumber},{ord.CustomerName},{ord.State},{ord.TaxRate}," +
                      $"{ord.ProductType},{ord.Area},{ord.CostPerSquareFoot},{ord.LaborCostPerSquareFoot},{ord.MaterialCost}," +
                      $"{ord.LaborCost},{ord.Tax},{ord.Total}");
                    }
                }
                //have to close streamwrited or it will not write data
                sw.Close();
            }
            return true;
        }
    }
}
