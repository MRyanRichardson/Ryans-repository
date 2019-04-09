using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using GuildCarsData;

namespace GuildCarsModel.Model
{
    public class VehicleAll
    {
        public string vehiclepic { get; set; }
        public bool Featured { get; set; }
        [Required(ErrorMessage = "Please select a make")]
        public int MakeId { get; set; }
        public SelectList slMakesNew { get; set; }
        [Required(ErrorMessage = "Please select a model")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Please input a year")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Please select whether the vehicle is new or used")]
        public bool New { get; set; }
        [Required(ErrorMessage = "Please select a body style")]
        public int BodyStyleId { get; set; }
        [Required(ErrorMessage = "Please select whether the vehicle transmission is automatic or manual")]
        public bool AutomaticTrans { get; set; }
        [Required(ErrorMessage = "Please select the vehicle exterior color")]
        public int ColorId { get; set; }
        [Required(ErrorMessage = "Please select the vehicle interior color")]
        public int InteriorId { get; set; }
        [Required(ErrorMessage = "Please input the vehicle's mileage")]
        public int? Mileage { get; set; }
        [Required(ErrorMessage = "Please input the vehicle's VIN")]
        [StringLength(17, ErrorMessage = "VINs must be exactly 17 characters long", MinimumLength = 17)]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Please input the vehicle's sale price")]
        [DataType(DataType.Currency)]
        public int? SalePrice { get; set; }
        [Required(ErrorMessage = "Please input the vehicle's MSRP")]
        [DataType(DataType.Currency)]
        public int? MSRP { get; set; }
        [Required(ErrorMessage = "Please input a description for this vehicle")]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string Description { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please choose an image for this vehicle")]
        public List<BodyStyles> bodyStyles { get; set; }
        public List<ExteriorColors> colors { get; set; }
        public List<Interiors> interiors { get; set; }
        public List<Makes> makes { get; set; }
        public List<Models> models { get; set; }
        public IEnumerable<SelectListItem> slMakes { get; set; }
        public IEnumerable<SelectListItem> slColors { get; set; }
        public IEnumerable<SelectListItem> slInteriors { get; set; }
        public IEnumerable<SelectListItem> slBodyStyles { get; set; }
        public IEnumerable<SelectListItem> slModels { get; set; }
        public HttpPostedFileBase VehicleImage { get; set; }
        public Vehicles vehicleToEdit { get; set; }
        public Vehicles getVehicleById(int id)
        {
            Vehicles vehicle = new Vehicles();
            IGuildCars repo = Settings.GetRepository();
            repo.GetVehicleById(id);
            return vehicle;
        }
        public VehicleAll()
        {
            bodyStyles = Settings.GetRepository().GetBodyStyles();
            colors = Settings.GetRepository().GetColors();
            interiors = Settings.GetRepository().getInteriors();
            makes = Settings.GetRepository().GetMakes();
            models = Settings.GetRepository().GetModels();
            slMakes = from make in makes
                      orderby make.MakeType
                      select new SelectListItem()
                      {
                          Value = make.MakeID.ToString(),
                          Text = make.MakeType,
                      };
            slColors = from c in colors
                       orderby c.CarColor
                       select new SelectListItem()
                       {
                           Value = c.ColorID.ToString(),
                           Text = c.CarColor
                       };
            slInteriors = from i in interiors
                          orderby i.InteriorColor
                          select new SelectListItem()
                          {
                              Value = i.InteriorID.ToString(),
                              Text = i.InteriorColor
                          };
            slBodyStyles = from bs in bodyStyles
                           orderby bs.BodyStyleID
                           select new SelectListItem()
                           {
                               Value = bs.BodyStyleID.ToString(),
                               Text = bs.BodyStyleType
                           };
            slModels = from mods in models
                       orderby mods.ModelType
                       select new SelectListItem()
                       {
                           Value = mods.ModelID.ToString(),
                           Text = mods.ModelType
                       };
        }
        public VehicleAll(int id)
        {
            VehicleId = id;
            
            bodyStyles = Settings.GetRepository().GetBodyStyles();
            colors = Settings.GetRepository().GetColors();
            interiors = Settings.GetRepository().getInteriors();
            makes = Settings.GetRepository().GetMakes();
            models = Settings.GetRepository().GetModels();
            IGuildCars repo = Settings.GetRepository();

            vehicleToEdit = repo.GetVehicleById(id);
            Featured = vehicleToEdit.Featured;
            Makes currentMake = Settings.GetRepository().GetMakeByModelId(vehicleToEdit.ModelID);
            MakeId = currentMake.MakeID;
            slMakesNew = new SelectList(makes, "MakeID", "MakeType", currentMake.MakeID);
            slMakes = from make in makes
                      orderby make.MakeType
                      select new SelectListItem()
                      {
                          Value = make.MakeID.ToString(),
                          Text = make.MakeType,
                          Selected = (make.MakeID == currentMake.MakeID)
                      };
            slColors = from c in colors
                       orderby c.CarColor
                       select new SelectListItem()
                       {
                           Value = c.ColorID.ToString(),
                           Text = c.CarColor,
                           Selected = (c.ColorID == vehicleToEdit.ColorID)
                       };
            slInteriors = from i in interiors
                          orderby i.InteriorColor
                          select new SelectListItem()
                          {
                              Value = i.InteriorID.ToString(),
                              Text = i.InteriorColor,
                              Selected = (i.InteriorID == vehicleToEdit.InteriorID)
                          };
            slBodyStyles = from bs in bodyStyles
                           orderby bs.BodyStyleID
                           select new SelectListItem()
                           {
                               Value = bs.BodyStyleID.ToString(),
                               Text = bs.BodyStyleType,
                               Selected = (bs.BodyStyleID == vehicleToEdit.BodyStyleID)
                           };
            slModels = from mods in models
                       orderby mods.ModelType
                       select new SelectListItem()
                       {
                           Value = mods.ModelID.ToString(),
                           Text = mods.ModelType,
                           Selected = (mods.ModelID == vehicleToEdit.ModelID)
                       };
        }
    }
}
