using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FlooringMasteryModels.Responses
{
    public class OrderLookupResponse : Response
    {
        public Order Order { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
