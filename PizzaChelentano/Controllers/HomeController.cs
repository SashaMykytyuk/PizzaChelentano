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

        [HttpGet]
        public ActionResult Pizza()
        {
            List<Dish> list = dal.GelAllDishes().ToList().Where(x=>x.TypeDish == "pizza").ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Calcium()
        {
            List<Dish> list = dal.GelAllDishes().ToList().Where(x => x.TypeDish == "calcium").ToList();
            return View(list);
        }


        [HttpGet]
        public ActionResult Pancake()
        {
            List<Dish> list = dal.GelAllDishes().ToList().Where(x => x.TypeDish == "pancake").ToList();
            return View(list);
        }

    }
}