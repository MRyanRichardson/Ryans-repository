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
            return View();
        }
        public ActionResult Used()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
       
    }
}