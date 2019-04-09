using GuildCarsData;
using GuildCarsModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult New()
        {
            IGuildCars repo = Settings.GetRepository();
            List<VehicleDisplay> model = new List<VehicleDisplay>();
            model = (repo.GetNew());
            return View(model);

        }
        public ActionResult Used()
        {
            IGuildCars repo = Settings.GetRepository();
            List<VehicleDisplay> model = new List<VehicleDisplay>();
            model = (repo.GetUsed());
            return View(model);
        }

        public ActionResult Details(int id) 
        {
            IGuildCars repo = Settings.GetRepository();
           VehicleDisplay model = new VehicleDisplay();
            model = (repo.GetById(id));
            return View(model);
        }

    }
}