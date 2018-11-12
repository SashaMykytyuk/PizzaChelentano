using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaChelentano.Models;

namespace PizzaChelentano.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL dal = new DAL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = dal.FindDishByName("dfdv") == null ? "not found" : "Ok";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}