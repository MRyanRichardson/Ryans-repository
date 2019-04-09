using FlooringMasteryModels;
using FlooringMasteryModels.Interfaces;
using FlooringMasteryModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
namespace FlooringMastery.BLL
{
    public class OrderManager
    {   // Setting to test or production 
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // returns a single order based on orderDate and the OrderNumber. 
        public OrderLookupResponse OrderLookup(DateTime orderDate, int orderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            response.Order = _orderRepository.LoadOrder(orderDate, orderNumber);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Orders_{orderDate}.txt is not a valid order file";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        //lookup order by date and ordernumber the use delete order to delete the order that they specified
        public OrderRemoveResponse RemoveOrder(DateTime date, int orderNumber)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();
            response.Success = _orderRepository.DeleteOrder(date, orderNumber);
            return response;
        }
        // checking if orders are there and returning the list of orders associated with the datefile --> Orderlookup method returns a single order for specific date.
        public OrderLookupResponse OrderLookupByDate(DateTime orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            response.OrderList = _orderRepository.LoadOrderByDate(orderDate);
            if (response.Order == null && response.OrderList == null)
            {
                response.Success = false;
                response.Message = $"Orders_{orderDate}.txt is not a valid order file";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
        //Add order by orderdate and the order created in the ui that we want to update
        public OrderAddResponse OrderAdd(DateTime orderDate, Order order)
        {
            OrderAddResponse response = new OrderAddResponse();
            // Check for tax information to see if state can be found or not
            bool foundError = false;
            if (!LookupTax(order))
            {
                response.Success = false;
                response.Message = $"Tax information could not be found for state: {order.State}\n";
                foundError = true;
            }
            if (!LookupProduct(order))
            {
                response.Success = false;
                // Add response error message and append to tax error message if necessary.
                response.Message += $"Product information could not be found for product: {order.ProductType}\n ";
                foundError = true;
            }
            if (foundError)
            {
                return response;
            }
            // calculating the cost of our product and taxes
            CalculateCost(order);
            if (_orderRepository.SaveOrder(orderDate, order))
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Order did not save correctly";
            }
            return response;
        }
        //Edit order specified by orderdate and the order that is passed in from the UI
        public OrderEditResponse OrderEdit(DateTime orderDate, Order order)
        {
            bool foundError = false;
            OrderEditResponse response = new OrderEditResponse();
            if (!LookupTax(order))
            {
                response.Success = false;
                response.Message = $"Tax information could not be found for state: {order.State}\n";
                foundError = true;
            }
            if (!LookupProduct(order))
            {
                response.Success = false;
                // Add response error message and append to tax error message if necessary.
                response.Message += $"Product information could not be found for product: {order.ProductType}\n ";
                foundError = true;
            }
            if (foundError)
            {
                return response;
            }
            // calculating the cost of our product and taxes
            CalculateCost(order);
            if (_orderRepository.SaveOrder(orderDate, order))
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Order did not save correctly";
            }
            return response;
        }
        // look up tax info for order based on state information
        private bool LookupTax(Order order)
        {
            List<Tax> lTax = _orderRepository.getTaxes();
            var taxes = lTax.FirstOrDefault(l => l.StateAbbreviation.ToUpper() == order.State.ToUpper());
            if (taxes != null)
            {
                order.State = taxes.StateAbbreviation;
                order.TaxRate = taxes.TaxRate;
                return true;
            }
            else
            {
                return false;
            }
        }
        //looking up the product by product type specified on the order
        private bool LookupProduct(Order order)
        {
            List<Product> lProduct = _orderRepository.getProducts();
            var products = lProduct.FirstOrDefault(l => l.ProductType.ToUpper() == order.ProductType.ToUpper());
            if (products != null)
            {
                order.ProductType = products.ProductType;
                order.LaborCostPerSquareFoot = products.LaborCostPerSquareFoot;
                order.CostPerSquareFoot = products.CostPerSquareFoot;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Calculating our cost for our orders
        /*MaterialCost = (Area * CostPerSquareFoot)
            LaborCost = (Area * LaborCostPerSquareFoot)
            Tax = ((MaterialCost + LaborCost) * (TaxRate / 100))
            Tax rates are stored as whole numbers
            Total = (MaterialCost + LaborCost + Tax) */
        private bool CalculateCost(Order order)
        {
            decimal area = order.Area;
            order.MaterialCost = Math.Round(area * order.CostPerSquareFoot, 2);
            order.LaborCost = Math.Round(area * order.LaborCostPerSquareFoot, 2);
            order.Tax = Math.Round((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100), 2);
            order.Total = Math.Round(order.MaterialCost + order.LaborCost + order.Tax, 2);
            return true;
        }
        //reutrns list of products file
        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            productList = _orderRepository.getProducts();
            return productList;
            throw new NotFiniteNumberException();
        }
        //return tax information from tax file
        public List<Tax> GetStates()
        {
            List<Tax> taxList = new List<Tax>();
            taxList = _orderRepository.getTaxes();
            return taxList;
        }
    }
}