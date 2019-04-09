using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuildCarsMVC.Controllers
{
    public class HomeController : Controller
    {
        //returns the view of our home page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Specials()
        {
            return View();
        }
    }
}