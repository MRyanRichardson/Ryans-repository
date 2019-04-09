using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsModel.Model
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
        public string City { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeName { get; set; }



    }
}
