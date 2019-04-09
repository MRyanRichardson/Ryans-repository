
using GuildCarsUI.Models;
using GuildCarsUI.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCarsUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword()
        {
            PasswordVM model = new PasswordVM();

            model.UserId = User.Identity.GetUserId();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ChangePassword(PasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(new GuildCarsDbContext()));

                AppUser user = userMgr.FindById(model.UserId);

                if (user != null)
                {
                    if (userMgr.CheckPassword(user, model.OldPassword))
                    {
                        try
                        {
                            userMgr.ChangePassword(user.Id, model.OldPassword, model.Password);
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);

                            return View(model);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password you provided does not match your current password. Try again.");

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "There was an issue with your account. Please sign out, then sign in and try changing your password again. Contact your system administator if the problem persists.");

                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}