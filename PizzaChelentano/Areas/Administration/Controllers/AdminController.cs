using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PizzaChelentano.Areas.Administration.Models;
using PizzaChelentano.Models;

namespace PizzaChelentano.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {

        private PizzaUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<PizzaUserManager>();
            }
        }

        // GET: Administration/Admin
        [HttpGet]
        public ActionResult Users()
        {
            List<UserForAdmin> userForAdmin = new List<UserForAdmin>();
            var list =  UserManager.Users.ToList();
            Debug.WriteLine("User count = " + list.Count);
            foreach (PizzaUser pizzaUser in list)
            {
                userForAdmin.Add(new UserForAdmin()
                {
                    Id = pizzaUser.Id,Name = pizzaUser.UserName,Email = pizzaUser.Email,
                    Discount = pizzaUser.Discount,House = pizzaUser.House,NumberApartment = pizzaUser.NumberApartment,
                    Phone = pizzaUser.PhoneNumber, Street = pizzaUser.Street,Role = pizzaUser.Roles.ToString(),
                    Orders = pizzaUser.Orders
                });
            }
            Debug.WriteLine("User count = " + userForAdmin.Count);
            return View(userForAdmin);
        }

       
    }
}