using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;



namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            Console.WriteLine("Exercise 1: ");
            Console.WriteLine();
            Exercise1();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 2: ");
            Console.WriteLine();
            Exercise2();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 3: ");
            Console.WriteLine();
            Exercise3();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 4: ");
            Console.WriteLine();
            Exercise4();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 5: ");
            Console.WriteLine();
            Exercise5();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 6: ");
            Console.WriteLine();
            Exercise6();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 7: ");
            Console.WriteLine();
            Exercise7();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 8: ");
            Console.WriteLine();
            Exercise8();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 9: ");
            Console.WriteLine();
            Exercise9();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 10: ");
            Console.WriteLine();
            Exercise10();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 11: ");
            Console.WriteLine();
            Exercise11();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 12: ");
            Console.WriteLine();
            Exercise12();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 13: ");
            Console.WriteLine();
            Exercise13();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 14: ");
            Console.WriteLine();
            Exercise14();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 15: ");
            Console.WriteLine();
            Exercise15();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 16: ");
            Console.WriteLine();
            Exercise16();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 17: ");
            Console.WriteLine();
            Exercise17();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 18: ");
            Console.WriteLine();
            Exercise18();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 19: ");
            Console.WriteLine();
            Exercise19();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 20: ");
            Console.WriteLine();
            Exercise20();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 21: ");
            Console.WriteLine();
            Exercise21();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 22: ");
            Console.WriteLine();
            Exercise22();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 23: ");
            Console.WriteLine();
            Exercise23();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 24: ");
            Console.WriteLine();
            Exercise24();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 25: ");
            Console.WriteLine();
            Exercise25();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 26: ");
            Console.WriteLine();
            Exercise26();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 27: ");
            Console.WriteLine();
            Exercise27();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 28: ");
            Console.WriteLine();
            Exercise28();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 29: ");
            Console.WriteLine();
            Exercise29();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 30: ");
            Console.WriteLine();
            Exercise30();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Exercise 31: ");
            Console.WriteLine();
            Exercise31();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {  //load products from dataloader
            //create var for out of stock
            //print which units are out of stock

            List<Product> product = DataLoader.LoadProducts(); // load all products
            var outOfStock = product.Where(p => p.UnitsInStock == 0); //set out of stock to unit stocks = 0
            PrintProductInformation(outOfStock); //print the items out of stock

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {   //load products from dataloader
            //create var to check if units in stock are greater than zero
            //print which items are in stock

            List<Product> product = DataLoader.LoadProducts();
            var inStock = product.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            PrintProductInformation(inStock);


        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {   // load customers from dataloader 
            // create var to check to see if customer lives in washington region
            // print customer information for washington

            List<Customer> customer = DataLoader.LoadCustomers();
            var washington = customer.Where(c => c.Region == "WA");
            PrintCustomerInformation(washington);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            //load products from dataloader and put into var product name
            //set prod to product name
            //create for each to loop through productnames
            //write out product name 

            var productName = from p in DataLoader.LoadProducts()
                              select new { prod = p.ProductName };

            foreach (var product in productName)
            {
                Console.WriteLine(product.prod);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()

        {   //get code for product information
            //dataloader.LoadProducts
            //create new unit price and set unit to multiply by decimal
            //for each to loop through items in collection
            //write out all products in products

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");


            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               p.Category,
                               newUnitPrice = p.UnitPrice * 1.25M,
                               p.UnitsInStock
                           };

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.newUnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            //create new all caps and set product name and category to upper
            // create foreach to loop through the products in collection
            // writeline the uppercase products

            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");


            var products = from p in DataLoader.LoadProducts()
                           select new
                           {
                               pAllCaps = p.ProductName.ToUpper(),
                               cAllCaps = p.Category.ToUpper(),
                           };

            foreach (var product in products)
            {
                Console.WriteLine(line, product.pAllCaps, product.cAllCaps);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            //create reorder and check if units in stock is < 3
            //if so set to true if not set to false
            //use foreach to loop through products
            //write out products

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("==============================================================================");


            var products = from p in DataLoader.LoadProducts()

                           select new
                           {
                               p.ProductID,
                               p.ProductName,
                               p.Category,
                               p.UnitPrice,
                               p.UnitsInStock,
                               reOrder = p.UnitsInStock < 3 ? true : false
                           };

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.reOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            //set stockvalue to unit price * units in stock

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stockvalue");
            Console.WriteLine("==============================================================================");


            var products = from p in DataLoader.LoadProducts()

                           select new
                           {

                               p.ProductID,
                               p.ProductName,
                               p.Category,
                               p.UnitPrice,
                               p.UnitsInStock,
                               StockValue = p.UnitPrice * p.UnitsInStock,
                           };

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            // use modulus to check if even number
            //use foreach to loop through var
            //if even number
            //write out even number

            var evens = from number in DataLoader.NumbersA.ToList()
                        where number % 2 == 0
                        select number;

            foreach (int i in evens)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()

        {
            //create allcustomers
            //set customer id and company name 
            //create tot to sum the total
           //where tot is > 0 and < 500
           //foreach cust in order console writeline

            List<Customer> customers = DataLoader.LoadCustomers();

            var allCustomers = (from c in customers
                                select new
                                {
                                    c.CustomerID,
                                    c.CompanyName,
                                    tot = c.Orders.Sum(t => t.Total)
                                });

            var order = (from cust in allCustomers.Where(t => t.tot > 0 && t.tot < 500)
                         orderby (cust.CompanyName)
                         select cust);

            Console.WriteLine(" | Customer ID     | Customer Name                            |Totals");
            Console.WriteLine("==============================================================================");

            string line = " | {0,-15} | {1,-40} | {2,10} |";

            foreach (var cust in order)
            {

                Console.WriteLine(line, cust.CustomerID, cust.CompanyName, cust.tot);

            }
        }
        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            // use var to see if the number in list are odd
            //if odd use foreach to write out odd number
            //use .Take() to only select the first 3

            var odds = (from number in DataLoader.NumbersC.ToList()
                        where number % 2 == 1
                        select number).Take(3);

            foreach (int i in odds)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            //public static int[] NumbersB = { 1, 3, 5, 7, 8 };
            //load numbers b and make them into a list
            //create a var to make sure num is greater than 0
            //use skip to skip the first 3 nums
            // write out the nums that are past the first 3

            var odds = (from number in DataLoader.NumbersB.ToList()
                        where number > 0
                        select number).Skip(3);

            foreach (int i in odds)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            //use first to print out the most recent order.
            //use if to see if customer region is washington
            //use order by descending to get the most recent order

            List<Customer> customers = DataLoader.LoadCustomers();

            foreach (var customer in customers)
            {
                if (customer.Region == "WA")
                {
                    var orderTheList = (from t in customer.Orders
                                        orderby t.OrderDate descending
                                        select t).First();

                    Console.WriteLine("==============================================================================");
                    Console.WriteLine(customer.CompanyName);
                    Console.WriteLine(customer.Region);


                    Console.WriteLine("\tOrders");

                    Console.WriteLine($"{ orderTheList.OrderID}  {orderTheList.OrderDate}  {orderTheList.Total}");

                    Console.WriteLine("==============================================================================");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
           //load NumbersC to list
           // Use Takewhile our number is less than 6
           //foreach number in nums write out number

            List<int> six = DataLoader.NumbersC.ToList();

            var nums = six.TakeWhile(number => number < 6);

            foreach (int number in nums)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            //SkipWhile n % 3 == 0
            //skip 1 so that you use the number after
            //write out 

            List<int> divThree = DataLoader.NumbersC.ToList();

            var odds = divThree.SkipWhile(n => n % 3 != 0).Skip(1);

            foreach (int n in odds)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {   //order by the product name

            //List<Product> prod = DataLoader.LoadProducts();
            // var product = prod.OrderBy(p => p.ProductName);
            // PrintProductInformation(product);

            var product = from prod in DataLoader.LoadProducts()
                          orderby prod.ProductName
                          select prod;
            PrintProductInformation(product);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {   //use orderby descending

            //List<Product> prod = DataLoader.LoadProducts();
            //var product = prod.OrderByDescending(p => p.UnitsInStock);
            //PrintProductInformation(product);

            var product = from prod in DataLoader.LoadProducts()
                          orderby prod.UnitsInStock descending
                          select prod;
            PrintProductInformation(product);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {   //order by category and unit price by descending

            //List<Product> prod = DataLoader.LoadProducts();
            //var product = prod.OrderBy(p => p.Category)
            //    .ThenByDescending(p => p.UnitPrice);

            //PrintProductInformation(product);


            var product = from prod in DataLoader.LoadProducts()
                          orderby prod.Category,
                          prod.UnitPrice descending
                          select prod;
            PrintProductInformation(product);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            //use reverse

            List<int> reverseIt = DataLoader.NumbersB.ToList();

            reverseIt.Reverse();

            foreach (int i in reverseIt)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        ///     
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            //use grouby to group categories
            //write group.key which is what we are grouping out ex: writing out the category
            //write out product name

            List<Product> prod = DataLoader.LoadProducts();

            var products = prod.GroupBy(u => u.Category);

            foreach (var group in products)
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProductName}");
                }
                Console.WriteLine("\n\n");
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            // create var for customers
            // order by company name
            //group by year and month
            //display data

            List<Customer> customers = DataLoader.LoadCustomers();

            var custs = from c in customers
                        orderby c.CompanyName
                        select (
                                new
                                {
                                    customerName = c.CompanyName,
                                    Years = (from y in c.Orders
                                             group c.Orders by new { y.OrderDate.Year, y.OrderDate.Month, y.Total }
                                             into grp
                                             select new
                                             {
                                                 year = grp.Key.Year,
                                                 month = grp.Key.Month,
                                                 total = grp.Key.Total
                                             }
                                            )
                                }
                         );



            foreach (var customer in custs)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.customerName);
                Console.WriteLine();
                foreach (var year in customer.Years)
                {
                    Console.WriteLine("{0}", year.year);

                    Console.WriteLine("   {0} - {1}", year.month, year.total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }


        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            //group by category
            //select group first or default

            List<Product> prod = DataLoader.LoadProducts();
            var products = prod.GroupBy(p => p.Category).Select(grp => grp.FirstOrDefault());

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Category}");
            }

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            //use ternary to check and see if product does exist or does not

            List<Product> prod = DataLoader.LoadProducts();
            bool products = prod.Any(p => p.ProductID.Equals(789));

            Console.WriteLine("The productID for 789" + (products ? " exists" : " Does not exist"));

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            // where units in stock is zero
            //group by category
            //print the first or default category

            List<Product> prod = DataLoader.LoadProducts();
            var products = (prod.Where(p => p.UnitsInStock == 0))
                               .GroupBy(p => p.Category)
                               .Select(p => p.FirstOrDefault());

            foreach (var item in products)
            {
                Console.WriteLine(item.Category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            //use where to see if unit in stock is greater than zero
            //if true write out the categories
            //same code as above just setting units in stock to greater than zero

            List<Product> prod = DataLoader.LoadProducts();
            var products = (prod.Where(p => p.UnitsInStock > 0))
                               .GroupBy(p => p.Category)
                               .Select(p => p.FirstOrDefault());

            foreach (var item in products)
            {
                Console.WriteLine(item.Category);
            }

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            //public static int[] NumbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //use modulus to see if num in list is odd
            //use foreach to loop through list
            //use if to verify num is odd
            //writeline

            var odds = from number in DataLoader.NumbersA.ToList()
                       where number % 2 == 1
                       select number;

            foreach (int i in odds)
            {

                Console.WriteLine(i);

            }

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            //load customer
            //order by customer id
            //count orders
            //select new and set id and order to new id and order
            //calll new order and id in writeline

            var customerName = from p in DataLoader.LoadCustomers()
                               orderby p.CustomerID,
                               p.Orders.Count()
                               select (
                               new
                               {
                                   customerID = p.CustomerID,
                                   orderCount = p.Orders.Count()
                               });

            string line = "{0,-15} {1,10} ";
            Console.WriteLine(line, "CustomerID", "Count");
            Console.WriteLine("==================================");

            foreach (var product in customerName)
            {
                Console.WriteLine(line, product.customerID, product.orderCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            //group by category 
            //lg= local group. category is set to key
            //count category
            List<Product> products = DataLoader.LoadProducts();


            var categoryCount = products.GroupBy(grp => grp.Category)
                       .Select(lg => new { category = lg.Key, count = lg.Count() });

            string line = "{0,-15} {1,7} ";
            Console.WriteLine(line, "Category", "Count");
            Console.WriteLine("==================================");

            foreach (var item in categoryCount)
            {
                Console.WriteLine(line, item.category, item.count);

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            // var category count
            //select new categor and count
            //set category to key (category)
            //set count to sum of units in stock
            //write category and item count

            List<Product> products = DataLoader.LoadProducts();

            var categoryCount = products.GroupBy(grp => grp.Category)
            .Select(grp => new { category = grp.Key, count = grp.Sum(u => u.UnitsInStock) });

            string line = "{0,-15} {1,7} ";
            Console.WriteLine(line, "Category", "Sum");
            Console.WriteLine("==================================");

            foreach (var item in categoryCount)
            {
                Console.WriteLine(line, item.category, item.count);

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            // use min to get minimum price

            List<Product> products = DataLoader.LoadProducts();

            var categoryCount = products.GroupBy(grp => grp.Category)
            .Select(grp => new { category = grp.Key, minPrice = grp.Min(u => u.UnitPrice) });

            string line = "{0,-15} {1,7} ";
            Console.WriteLine(line, "Category", "Lowest price");
            Console.WriteLine("==================================");

            foreach (var item in categoryCount)
            {
                Console.WriteLine(line, item.category, item.minPrice);

            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            //select new categories and use average to get unit price
            //use take 3 to get top 3 
            List<Product> products = DataLoader.LoadProducts();

            var categoryCount = products.GroupBy(grp => grp.Category)
            .Select(grp => new { category = grp.Key, avgPrice = grp.Average(u => u.UnitPrice) })
            .OrderByDescending(grp => grp.avgPrice).Take(3);

            string line = "{0,-15} {1,7} ";
            Console.WriteLine(line, "Category", "Lowest price");
            Console.WriteLine("==================================");

            foreach (var item in categoryCount)
            {
                Console.WriteLine(line, item.category, item.avgPrice);

            }
        }
    }
}
