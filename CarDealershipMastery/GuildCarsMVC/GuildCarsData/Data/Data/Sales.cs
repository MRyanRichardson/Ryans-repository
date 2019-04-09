using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GuildCarsMVC.Data.Data
{
    public class Sales
    {
        public int SaleID { get; set; }
        public decimal SalePrice { get; set; }
        public int VehicleID { get; set; }
        public string CustomerName { get; set; }
        public int UserID { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}