using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FlooringMasteryModels.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(DateTime orderDate, int orderNumber);
        List<Order> LoadOrderByDate(DateTime orderDate);
        bool SaveOrder(DateTime orderDate, Order order);
        bool DeleteOrder(DateTime orderDate, int orderNumber);
        List<Tax> getTaxes();
        List<Product> getProducts();
    }
}
