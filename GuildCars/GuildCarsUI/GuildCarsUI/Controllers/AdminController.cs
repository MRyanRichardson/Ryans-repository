using GuildCarsData;
using GuildCarsModel.Model;
using GuildCarsUI.Models;
using GuildCarsUI.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GuildCarsUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Vehicles()
        {
            IGuildCars repo = Settings.GetRepository();
            List<VehicleDisplay> model = new List<VehicleDisplay>();
            model = (repo.GetAll(false));
            return View(model);
        }
        public ActionResult AddVehicle()
        {
            IGuildCars repo = Settings.GetRepository();
            VehicleAll model = new VehicleAll(0);
           // model = repo.getVehicleAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddVehicle(VehicleAll vehicle)
        {
            IGuildCars repo = Settings.GetRepository();
            if (ModelState.IsValid)
            {
                Vehicles model = new Vehicles()
                {
                    Year = Convert.ToInt32(vehicle.Year),
                    BodyStyleID = vehicle.BodyStyleId,
                    ColorID = vehicle.ColorId,
                    Mileage = Convert.ToInt32(vehicle.Mileage),
                    VIN = vehicle.VIN,
                    ModelID = vehicle.ModelId,
                    InteriorID = vehicle.InteriorId,
                    SalePrice = Convert.ToInt32(vehicle.Year),
                    MSRP = Convert.ToDecimal(vehicle.MSRP),
                    UserID = 1,
                    TransmissionID = Convert.ToInt32(vehicle.AutomaticTrans) + 1,
                    Featured = vehicle.Featured,
                    Description = vehicle.Description,
                    New = vehicle.New
                };

                int newId = repo.AddVehicle(model);
                if (vehicle.VehicleImage != null && vehicle.VehicleImage.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), "inventory-" + newId.ToString() + ".png");
                    vehicle.VehicleImage.SaveAs(path);

                }
                return RedirectToAction("EditVehicle", new { id = newId });
            }
            else
            {
                return View(vehicle);
            }
        }
        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            IGuildCars repo = Settings.GetRepository();
            VehicleAll model = new VehicleAll(id);
            model.slMakesNew = new SelectList(model.makes, "MakeID", "MakeType", 2);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditVehicle(VehicleAll vehicle)
        {
            IGuildCars repo = Settings.GetRepository();
            Vehicles model = new Vehicles();
            model = repo.GetVehicleById(vehicle.VehicleId);
            model.Year = Convert.ToInt32(vehicle.Year);
            model.BodyStyleID = vehicle.BodyStyleId;
            model.ColorID = vehicle.ColorId;
            model.Mileage = Convert.ToInt32(vehicle.Mileage);
            model.VIN = vehicle.VIN;
            model.ModelID = vehicle.ModelId;
            model.InteriorID = vehicle.InteriorId;
            model.SalePrice = Convert.ToInt32(vehicle.Year);
            model.MSRP = Convert.ToDecimal(vehicle.MSRP);
            model.UserID = 1;
            model.TransmissionID = Convert.ToInt32(vehicle.AutomaticTrans) + 1;
            model.Featured = vehicle.Featured;
            model.Description = vehicle.Description;
            model.New = vehicle.New;
            model.Featured = vehicle.Featured;
            repo.EditVehicle(model);
            if (vehicle.VehicleImage != null && vehicle.VehicleImage.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), "inventory-" + vehicle.VehicleId.ToString() + ".png");
                vehicle.VehicleImage.SaveAs(path);
            }
            else
            {
                string path = Path.Combine(Server.MapPath("~/Images"), "inventory-" + vehicle.VehicleId.ToString() + ".png");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return RedirectToAction("Vehicles");
        }


      
        public ActionResult DeleteVehicle(int id)
        {
            IGuildCars repo = Settings.GetRepository();
            Vehicles v = repo.GetVehicleById(id);
            repo.DeleteVehicle(v.VehicleID);
           
          
                string path = Path.Combine(Server.MapPath("~/Images"), "inventory-" + v.VehicleID.ToString() + ".png");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

           
            
            return RedirectToAction("Vehicles");
        }
        [HttpGet]
        public ActionResult Users()
        {
            GuildCarsDbContext repo = new GuildCarsDbContext();
            List<UsersVM> model = (from user in repo.Users
                                   select new
                                   {
                                       UserId = user.Id,
                                       UserName = user.UserName,
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       Email = user.Email,
                                       RoleNames = (from userRole in user.Roles
                                                    join role in repo.Roles on userRole.RoleId
                                                    equals role.Id
                                                    select role.Name).ToList()
                                   }).ToList().Select(u => new UsersVM()
                                   {
                                       UserId = u.UserId,
                                       UserName = u.UserName,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName,
                                       Email = u.Email,
                                       RoleName = string.Join(", ", u.RoleNames)
                                   }).OrderBy(v => v.LastName).ToList();
            return View(model);
        }
        public ActionResult AddUser()
        {
            GuildCarsDbContext IdentityRepo = new GuildCarsDbContext();
            AddUserVM model = new AddUserVM()
            {
                Roles = from role in IdentityRepo.Roles
                        orderby role.Name
                        select new SelectListItem()
                        {
                            Text = role.Name,
                            Value = role.Name
                        }
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(AddUserVM model)
        {
            GuildCarsDbContext IdentityRepo = new GuildCarsDbContext();
            if (ModelState.IsValid)
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(IdentityRepo));
                var user = new AppUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                userMgr.Create(user, model.Password);
                userMgr.AddToRole(user.Id, model.RoleName);
                return RedirectToAction("Users");
            }
            else
            {
                model.Roles = from role in IdentityRepo.Roles
                              orderby role.Name
                              select new SelectListItem()
                              {
                                  Text = role.Name,
                                  Value = role.Name
                              };
                return View(model);
            }
        }
        [HttpGet]
        [Route("Admin/EditUser/{userId}")]
        public ActionResult EditUser(string userId)
        {
            GuildCarsDbContext repo = new GuildCarsDbContext();
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(repo));
            AppUser user = userMgr.FindById(userId);
            if (user != null)
            {
                EditUserVM model = new EditUserVM()
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = from role in repo.Roles
                            orderby role.Name
                            select new SelectListItem()
                            {
                                Text = role.Name,
                                Value = role.Name
                            }
                };
                var userRoles = userMgr.GetRoles(userId);
                foreach (var role in userRoles)
                {
                    model.RoleName += role;
                    if (role != userRoles.Last())
                        model.RoleName += ", ";
                }
                return View(model);
            }
            else
            {
                // COMMENT: how to handle if user is not found above? Show error?
                return RedirectToAction("Users");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserVM model)
        {
            GuildCarsDbContext repo = new GuildCarsDbContext();
            if (ModelState.IsValid)
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(repo));
                var user = userMgr.FindById(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    if (!userMgr.IsInRole(user.Id, model.RoleName))
                    {
                        userMgr.RemoveFromRoles(user.Id, userMgr.GetRoles(user.Id).ToArray());
                        userMgr.AddToRole(user.Id, model.RoleName);
                    }
                    if (model.Password != null)
                    {
                        userMgr.RemovePassword(user.Id);
                        userMgr.AddPassword(user.Id, model.Password);
                    }
                    userMgr.Update(user);
                    return RedirectToAction("Users");
                }
                else
                {
                    ModelState.AddModelError("", "Can't find user's account.");
                    return View(model);
                }
            }
            else
            {
                model.Roles = from role in repo.Roles
                              orderby role.Name
                              select new SelectListItem()
                              {
                                  Text = role.Name,
                                  Value = role.Name
                              };
                return View(model);
            }
        }
        public ActionResult Makes()
        {
            IGuildCars repo = Settings.GetRepository();
            MakesVM makesVM = new MakesVM()
            {
                Makes = repo.GetMakes()
            };
            return View(makesVM);
        }
        [HttpPost]
        public ActionResult AddMake(MakesVM model)
        {
            IGuildCars repo = Settings.GetRepository();
            if (ModelState.IsValid)
            {
                Makes make = new Makes()
                {
                    MakeType = model.MakeName,
                    DateAdd = DateTime.Now,
                    UserID = 1
                };
                repo.AddMake(make);
            }
            else
            {
                model.Makes = repo.GetMakes();
                return View("Makes", model);
            }
            return RedirectToAction("Makes");
        }
        [HttpPost]
        public ActionResult AddModel(ModelsVM model, FormCollection form)
        {
            IGuildCars repo = Settings.GetRepository();
            if (ModelState.IsValid)
            {
                GuildCarsModel.Model.Models mod = new GuildCarsModel.Model.Models()
                {
                    ModelType = model.modelToAdd.ModelType,
                    MakeID = Convert.ToInt32(form["ddlMakes"].ToString()),
                    DateAdded = DateTime.Now,
                    UserId = 1
                };
                repo.AddModel(mod);
            }
            else
            {
                model.MakeModels = repo.GetMakeModels();
                model.Makes = repo.GetMakes();
                model.modelToAdd = new GuildCarsModel.Model.Models();
                return View("Models", model);
            }
            return RedirectToAction("Models");
        }
        [HttpGet]
        public ActionResult Models()
        {
            IGuildCars repo = Settings.GetRepository();
            ModelsVM modelVM = new ModelsVM()
            {
                MakeModels = repo.GetMakeModels(),
                Makes = repo.GetMakes(),
                modelToAdd = new GuildCarsModel.Model.Models()
            };
            return View(modelVM);
        }
        [HttpGet]
        public ActionResult Specials()
        {
            IGuildCars repo = Settings.GetRepository();
            SpecialsVM spvm = new SpecialsVM()
            {
                special = repo.GetSpecials()
            };
            return View(spvm);
        }
        [HttpPost]
        public ActionResult AddSpecials(SpecialsVM specials)
        {
            IGuildCars repo = Settings.GetRepository();
            Specials special = new Specials()
            {
                SpecialType = specials.SpecialType,
                SpecialDescription = specials.specialDescription,
                UserID = 1
            };
            repo.AddSpecial(special);
            return RedirectToAction("Specials");
        }
        public ActionResult DeleteSpecials(int id)
        {
            IGuildCars repo = Settings.GetRepository();
            repo.DeleteSpecials(id);
            return RedirectToAction("Specials");
        }
        public ActionResult DeleteSpecialsConfirm(Specials model)
        {
            return View(model);
        }
    }
}