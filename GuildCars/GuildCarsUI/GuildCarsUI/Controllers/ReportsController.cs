using GuildCarsData;
using GuildCarsModel.Model;
using GuildCarsUI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Inventory()
        {
            IGuildCars repo = Settings.GetRepository();
            InventoryVM invVM = new InventoryVM();
            invVM.InventoryNew = repo.GetInventory(true);
            invVM.InventoryUsed = repo.GetInventory(false);
            return View(invVM);
        }

        [HttpGet]
        public ActionResult Sales()
        {

            SalesVM salesVM = new SalesVM();
            IGuildCars repo = Settings.GetRepository();
            salesVM.lUsers = repo.GetUsers();


           salesVM.model = (from user in salesVM.lUsers
                                          orderby user.FirstName
                                          select new SelectListItem()
                                          {
                                              Text = user.UserName,
                                              Value = user.UserID.ToString()
                                          }).ToList();

            return View(salesVM);
        }
    }
}