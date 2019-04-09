using GuildCarsData;
using GuildCarsModel.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuildCarsUI.Controllers
{ 
    public class HomeController : Controller
    {
        //returns the view of our home page
        public ActionResult Index()
        {
            IGuildCars repo = Settings.GetRepository();
            SpecialAndFeatured model = new SpecialAndFeatured();
            model = (repo.GetSpecialAndFeatured());
            return View(model);
        }
        //Model.VIN , Model.Year , Model.MakeType , Model.ModelType
        public ActionResult Contact(string VIN, string MakeType, string ModelType)
        {
            string mod = MakeType + " " + ModelType + "" + VIN;
            string response = "Hello i am interested in getting more details on your " + "" + mod;

            if ( VIN != null && MakeType != null && ModelType != null)
            {
                return View((object)response);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Specials()
        {
            IGuildCars repo = Settings.GetRepository();
            List<Specials> model = new List<Specials>();
            model = (repo.GetSpecials());
            return View(model);
        }

     
    }
}