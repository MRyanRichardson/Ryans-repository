using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuildCarsModel.Model
{
    public class VehicleDisplay
    {
        public int VehicleID { get; set; }
        public int Year { get; set; }
        public string ModelType { get; set; }
        public string BodyStyleType { get; set; }
        public string CarColor { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public string InteriorColor { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string TransmissionType { get; set; }
        //question mark allows null
        public int? SaleID { get; set; }
        public int UserID { get; set; }
        public bool Featured { get; set; }
        public string MakeType { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public bool New { get; set; }
    }
}
