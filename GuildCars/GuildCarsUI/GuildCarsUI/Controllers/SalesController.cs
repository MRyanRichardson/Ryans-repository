﻿using GuildCarsData;
using GuildCarsModel.Model;
using GuildCarsUI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuildCarsUI.Controllers
{
    public class SalesController : Controller
    {
        //authorize salesman to do sales
        [Authorize(Roles = "Admin,Sales")]
        public ActionResult Index()
        {
            IGuildCars repo = Settings.GetRepository();
            List<VehicleDisplay> model = new List<VehicleDisplay>();
            model = (repo.GetAvailable());
            return View(model);
        }
        //sales/purchase/id


        public ActionResult Purchase(int id)
        {
            IGuildCars repo = Settings.GetRepository();
            PurchaseVM purchaseVM = new PurchaseVM();
            purchaseVM.Vehicle = repo.GetById(id);
            purchaseVM.Customer = new CustomerVM();

            purchaseVM.FinanceTypes = new SelectList(
                      new List<SelectListItem>
                      {
                                new SelectListItem { Selected = true, Text = "Bank Finance", Value = "Dealer"},
                                new SelectListItem { Selected = false, Text = "Cash", Value = "Cash"},
                                new SelectListItem { Selected = false, Text = "Dealer Finance", Value = "Personal"},
                      }, "Value", "Text", 1);



            purchaseVM.States = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem() {Text="AL", Value="AL"},
            new SelectListItem() { Text="AK", Value="AK"},
            new SelectListItem() { Text="AZ", Value="AZ"},
            new SelectListItem() { Text="AR", Value="AR"},
            new SelectListItem() { Text="CA", Value="CA"},
            new SelectListItem() { Text="CO", Value="CO"},
            new SelectListItem() { Text="CT", Value="CT"},
            new SelectListItem() { Text="DC", Value="DC"},
            new SelectListItem() { Text="DE", Value="DE"},
            new SelectListItem() { Text="FL", Value="FL"},
            new SelectListItem() { Text="GA", Value="GA"},
            new SelectListItem() { Text="HI", Value="HI"},
            new SelectListItem() { Text="ID", Value="ID"},
            new SelectListItem() { Text="IL", Value="IL"},
            new SelectListItem() { Text="IN", Value="IN"},
            new SelectListItem() { Text="IA", Value="IA"},
            new SelectListItem() { Text="KS", Value="KS"},
            new SelectListItem() { Text="KY", Value="KY"},
            new SelectListItem() { Text="LA", Value="LA"},
            new SelectListItem() { Text="ME", Value="ME"},
            new SelectListItem() { Text="MD", Value="MD"},
            new SelectListItem() { Text="MA", Value="MA"},
            new SelectListItem() { Text="MI", Value="MI"},
            new SelectListItem() { Text="MN", Value="MN"},
            new SelectListItem() { Text="MS", Value="MS"},
            new SelectListItem() { Text="MO", Value="MO"},
            new SelectListItem() { Text="MT", Value="MT"},
            new SelectListItem() { Text="NE", Value="NE"},
            new SelectListItem() { Text="NV", Value="NV"},
            new SelectListItem() { Text="NH", Value="NH"},
            new SelectListItem() { Text="NJ", Value="NJ"},
            new SelectListItem() { Text="NM", Value="NM"},
            new SelectListItem() { Text="NY", Value="NY"},
            new SelectListItem() { Text="NC", Value="NC"},
            new SelectListItem() { Text="ND", Value="ND"},
            new SelectListItem() { Text="OH", Value="OH"},
            new SelectListItem() { Text="OK", Value="OK"},
            new SelectListItem() { Text="OR", Value="OR"},
            new SelectListItem() { Text="PA", Value="PA"},
            new SelectListItem() { Text="PR", Value="PR"},
            new SelectListItem() { Text="RI", Value="RI"},
            new SelectListItem() { Text="SC", Value="SC"},
            new SelectListItem() { Text="SD", Value="SD"},
            new SelectListItem() { Text="TN", Value="TN"},
            new SelectListItem() { Text="TX", Value="TX"},
            new SelectListItem() { Text="UT", Value="UT"},
            new SelectListItem() { Text="VT", Value="VT"},
            new SelectListItem() { Text="VA", Value="VA"},
            new SelectListItem() { Text="WA", Value="WA"},
            new SelectListItem() { Text="WV", Value="WV"},
            new SelectListItem() { Text="WI", Value="WI"},
            new SelectListItem() { Text="WY", Value="WY"}
            }, "Value", "Text", 1);



            return View(purchaseVM);
        }



        [HttpPost]
        public ActionResult Purchase(PurchaseVM purchase)
        {
            IGuildCars repo = Settings.GetRepository();

            if (ModelState.IsValid)
            {
                Sales sale = new Sales() {

                    CustomerName = purchase.Customer.CustomerName,
                    Phone = purchase.Customer.Phone,
                    Email = purchase.Customer.Email,
                    CustomerAddress1 = purchase.Customer.Street1,
                    CustomerAddress2 = purchase.Customer.Street2,
                    SalePrice = purchase.Vehicle.SalePrice,
                    UserID = 1,
                    VehicleID = purchase.Vehicle.VehicleID,
                    City = purchase.Customer.City,
                    StateAbbreviation = purchase.Customer.StateId,
                    PurchaseTypeName = purchase.Customer.PurchaseTypeName,
                    StateName = purchase.Customer.StateId,
                    PurchaseDate = System.DateTime.Now,
                    ZipCode = purchase.Customer.ZipCode,
                    PurchasePrice= purchase.Customer.PurchasePrice
                    

                
                    

                };

                repo.AddPurchase(sale);

                return RedirectToAction("Index");
            }
            else
            {
                purchase.Vehicle = repo.GetById(purchase.Vehicle.VehicleID);
                purchase.States = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem() {Text="AL", Value="AL"},
            new SelectListItem() { Text="AK", Value="AK"},
            new SelectListItem() { Text="AZ", Value="AZ"},
            new SelectListItem() { Text="AR", Value="AR"},
            new SelectListItem() { Text="CA", Value="CA"},
            new SelectListItem() { Text="CO", Value="CO"},
            new SelectListItem() { Text="CT", Value="CT"},
            new SelectListItem() { Text="DC", Value="DC"},
            new SelectListItem() { Text="DE", Value="DE"},
            new SelectListItem() { Text="FL", Value="FL"},
            new SelectListItem() { Text="GA", Value="GA"},
            new SelectListItem() { Text="HI", Value="HI"},
            new SelectListItem() { Text="ID", Value="ID"},
            new SelectListItem() { Text="IL", Value="IL"},
            new SelectListItem() { Text="IN", Value="IN"},
            new SelectListItem() { Text="IA", Value="IA"},
            new SelectListItem() { Text="KS", Value="KS"},
            new SelectListItem() { Text="KY", Value="KY"},
            new SelectListItem() { Text="LA", Value="LA"},
            new SelectListItem() { Text="ME", Value="ME"},
            new SelectListItem() { Text="MD", Value="MD"},
            new SelectListItem() { Text="MA", Value="MA"},
            new SelectListItem() { Text="MI", Value="MI"},
            new SelectListItem() { Text="MN", Value="MN"},
            new SelectListItem() { Text="MS", Value="MS"},
            new SelectListItem() { Text="MO", Value="MO"},
            new SelectListItem() { Text="MT", Value="MT"},
            new SelectListItem() { Text="NE", Value="NE"},
            new SelectListItem() { Text="NV", Value="NV"},
            new SelectListItem() { Text="NH", Value="NH"},
            new SelectListItem() { Text="NJ", Value="NJ"},
            new SelectListItem() { Text="NM", Value="NM"},
            new SelectListItem() { Text="NY", Value="NY"},
            new SelectListItem() { Text="NC", Value="NC"},
            new SelectListItem() { Text="ND", Value="ND"},
            new SelectListItem() { Text="OH", Value="OH"},
            new SelectListItem() { Text="OK", Value="OK"},
            new SelectListItem() { Text="OR", Value="OR"},
            new SelectListItem() { Text="PA", Value="PA"},
            new SelectListItem() { Text="PR", Value="PR"},
            new SelectListItem() { Text="RI", Value="RI"},
            new SelectListItem() { Text="SC", Value="SC"},
            new SelectListItem() { Text="SD", Value="SD"},
            new SelectListItem() { Text="TN", Value="TN"},
            new SelectListItem() { Text="TX", Value="TX"},
            new SelectListItem() { Text="UT", Value="UT"},
            new SelectListItem() { Text="VT", Value="VT"},
            new SelectListItem() { Text="VA", Value="VA"},
            new SelectListItem() { Text="WA", Value="WA"},
            new SelectListItem() { Text="WV", Value="WV"},
            new SelectListItem() { Text="WI", Value="WI"},
            new SelectListItem() { Text="WY", Value="WY"}
            }, "Value", "Text", 1);
                purchase.FinanceTypes = new SelectList(
                       new List<SelectListItem>
                       {
                                new SelectListItem { Selected = true, Text = "Bank Finance", Value = "Dealer"},
                                new SelectListItem { Selected = false, Text = "Cash", Value = "Cash"},
                                new SelectListItem { Selected = false, Text = "Dealer Finance", Value = "Personal"},
                       }, "Value", "Text", 1);

                return View(purchase);
            }
        }
    }
}