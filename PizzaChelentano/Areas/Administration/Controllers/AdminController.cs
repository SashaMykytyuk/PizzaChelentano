using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        /// <summary>
        /// Work with Users 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Users()
        {
            List<UserForAdmin> userForAdmin = new List<UserForAdmin>();
            var list = UserManager.Users.ToList();
            //Debug.WriteLine("User count = " + list.Count);
            foreach (PizzaUser pizzaUser in list)
            {
                userForAdmin.Add(new UserForAdmin()
                {
                    Id = pizzaUser.Id,
                    Name = pizzaUser.UserName,
                    Email = pizzaUser.Email,
                    Discount = pizzaUser.Discount,
                    House = pizzaUser.House,
                    NumberApartment = pizzaUser.NumberApartment,
                    Phone = pizzaUser.PhoneNumber,
                    Street = pizzaUser.Street,
                    Role = pizzaUser.Role,
                    TimeRegistration = pizzaUser.TimeRegistration,
                    Orders = pizzaUser.Orders
                });
            }
            //Debug.WriteLine("User count = " + userForAdmin.Count);
            return View(userForAdmin);
        }
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            return View(GetUserForAdmin(id));
        }
        [HttpGet]
        public ActionResult DetailsUser(string id)
        {
            return View(GetUserForAdmin(id));
        }
        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            return View(GetUserForAdmin(id));
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(UserForAdmin userForAdmin)
        {
            PizzaUser user = await UserManager.FindByIdAsync(userForAdmin.Id);
            IdentityResult result = await UserManager.DeleteAsync(user);
            return RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserForAdmin model)
        {
            PizzaUser user = await UserManager.FindByIdAsync(model.Id);
            user.Discount = model.Discount;
            user.House = model.House;
            user.NumberApartment = model.NumberApartment;
            user.Street = model.Street;
            user.Role = model.Role;
            user.PhoneNumber = model.Phone;

            IdentityResult result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Что-то пошло не так");
            }
            return View(model);
        }

        private UserForAdmin GetUserForAdmin(string id)
        {
            var user = UserManager.Users.First(pizzaUser => pizzaUser.Id == id);
            return new UserForAdmin()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Discount = user.Discount,
                House = user.House,
                NumberApartment = user.NumberApartment,
                Phone = user.PhoneNumber,
                Street = user.Street,
                Role = user.Role,
                TimeRegistration = user.TimeRegistration,
                Orders = user.Orders
            };
        }


        /// <summary>
        /// Work with Dishes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Dishes()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateDishes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDishes(Dish dish)
        {
            //Extract Image File Name.
            string fileName = Path.GetFileName(dish.ImageFileBase.FileName);

            //Set the Image File Path.
            string filePath = "~/images/Dishes/" + fileName;

            //Save the Image File in Folder.
            dish.ImageFileBase.SaveAs(Server.MapPath(filePath));

            //Insert the Image File details in Table.
            Dish new_dish = new Dish()
            {
                Name = dish.Name,
                Cost = dish.Cost,
                Description = dish.Description,
                Weight = dish.Weight,
                ImageFileBase = dish.ImageFileBase
            };
            DAL dal = new DAL();
            dal.CreateDish(new_dish);
            return RedirectToAction("Dishes", "Admin");
        }





        /// <summary>
        /// Work with Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Orders()
        {
            return View();
        }
        /// <summary>
        /// Work with banners
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Banners()
        {
            return View();
        }
    }
}