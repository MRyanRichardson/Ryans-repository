using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuildCarsMVC.Controllers
{
    public class AdminController : Controller
    {
        // Admin/Vehicles
        public ActionResult Vehicles()
        {
            return View();
        }
        public ActionResult AddVehicle()
        {
            return View();
        }
        public ActionResult EditVehicle()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult EditUser()
        {
            return View();
        }
        public ActionResult Makes()
        {
            return View();
        }
        public ActionResult Models()
        {
            return View();
        }
        public ActionResult Specials()
        {
            return View();
        }
    }
}