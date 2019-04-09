using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace GuildCarsMVC.Models.Data
{
    public class Vehicles
    {
        public int VehicleID { get; set; }
        public int Year { get; set; }
        public int ModelID { get; set; }
        public int BodyStyleID { get; set; }
        public int ColorID { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int InteriorID { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public int TransmissionID { get; set; }
        //question mark allows null
        public int? SaleID { get; set; }
        public int UserID { get; set; }
        public bool Featured { get; set; }
    }
}