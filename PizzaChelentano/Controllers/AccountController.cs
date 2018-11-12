using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PizzaChelentano.Models;

namespace PizzaChelentano.Controllers
{
    public class AccountController : Controller
    {
        private PizzaUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<PizzaUserManager>();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                PizzaUser user = new PizzaUser
                {
                    UserName = model.Email, Email = model.Email,
                    Street = model.Street,
                    House = model.House,
                    NumberApartment = model.NumberApartment
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }
    }
}