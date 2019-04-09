using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMasteryModels.Responses;
using FlooringMastery.BLL;
using FlooringMasteryModels;
using FlooringMastery;
namespace FlooringMasteryTest
{   //CHANGED ALL TESTS TO RUN IN TEST REPOSITORY
    [TestFixture]
    class FlooringMasteryTest
    {// testing to lookup our accounts by orderdate and ordernumber
        [Test]
        [TestCase("10/28/1995", 2, true)]
        [TestCase("10/28/1995", 35, false)]
        [TestCase("02/20/2020", 1, false)]
        public void LookupAccountTest(DateTime orderDate, int orderNumber, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse olr = new OrderLookupResponse();
            olr = manager.OrderLookup(orderDate, orderNumber);
            Assert.AreEqual(expectedResult, olr.Success);
        }
        [Test]
        [TestCase("10/28/1995", true)]
        [TestCase("02/21/2019", false)]
        //lookup accounts by date 
        public void LookupAccountTestByDate(DateTime orderDate, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse olr = new OrderLookupResponse();
            olr = manager.OrderLookupByDate(orderDate);
            Assert.AreEqual(expectedResult, olr.Success);
        }
        [Test]
        [TestCase("10/28/1995", 0, "Ryan", "MI", "Carpet", 700, true)]
        [TestCase("10/28/1995", 0, "Ryan2", "IN", "Carpet", 500, true)]
        [TestCase("10/28/1995", 0, "Ryan2", "KY", "Carpet", 500, false)]
        [TestCase("10/28/1995", 0, "Ryan2", "IN", "Linoleum", 500, false)]
        [TestCase("10/28/1995", 0, "Ryan2", "", "Carpet", 500, false)]
        [TestCase("10/28/1995", 0, "Ryan2", "IN", "", 500, false)]
        [TestCase("02/01/2020", 0, "Ryan2", "KY", "Carpet", 500, false)]
        [TestCase("10/28/1995", 0, "Ryan2", "IN", "Wood", 500, true)]
        //add orders 
        public void AddOrderTest(DateTime date, int orderNum, string customerName, string state, string productType, decimal area, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderAddResponse oar = new OrderAddResponse();
            Order order = new Order();
            order.OrderNumber = orderNum;
            order.CustomerName = customerName;
            order.State = state;
            order.ProductType = productType;
            order.Area = area;
            oar = manager.OrderAdd(date, order);
            Assert.AreEqual(expectedResult, oar.Success);
        }
        [Test]
        [TestCase("10/28/1995", 1, "Ryan", "MI", "Carpet", 700, true)]
        [TestCase("10/28/1995", 1, "Ryan2", "IN", "Wood", 500, true)]
        [TestCase("10/28/1995", 1, "Ryan2", "KY", "Carpet", 500, false)]
        [TestCase("10/28/1995", 1, "Ryan2", "IN", "Linoleum", 500, false)]
        [TestCase("10/28/1995", 15, "Ryan2", "KY", "Carpet", 500, false)]
        [TestCase("10/28/1996", 1, "Ryan2", "IN", "Linoleum", 500, false)]
        // edit order based on date and ordernumber
        public void EditOrderTest(DateTime date, int orderNum, string customerName, string state, string productType, decimal area, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderEditResponse oer = new OrderEditResponse();
            Order order = new Order();
            order.OrderNumber = orderNum;
            order.CustomerName = customerName;
            order.State = state;
            order.ProductType = productType;
            order.Area = area;
            oer = manager.OrderEdit(date, order);
            Assert.AreEqual(expectedResult, oer.Success);
        }
        [Test]
        [TestCase("10/28/1995", 1, true)]
        [TestCase("10/28/1995", 0, true)]
        //delete orders based on date and ordernumber
        public void DeleteOrderTest(DateTime date, int orderNum, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderRemoveResponse oer = new OrderRemoveResponse();
            oer = manager.RemoveOrder(date, orderNum);
            Assert.AreEqual(expectedResult, oer.Success);
        }
        //Check Rules
        //Customer Name:
        [Test]
        [TestCase("Ryan", true)]
        [TestCase("Ryan Richardson", true)]
        [TestCase("Ryan@Richardson", false)]
        [TestCase("Ryan_Richardson", false)]
        [TestCase("", false)]

        public void CheckCustomerName(string customerName, bool expectedResult)
        {
            bool test = ConsoleRead.CheckCustomerName(customerName);
            Assert.AreEqual(expectedResult, test);
        }
    }
}