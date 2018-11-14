using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaChelentano.Models;

namespace PizzaChelentano.Areas.Administration.Models
{
    public class DishWithFile
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Cost { set; get; }
        public string Weight { set; get; }
        public string TypeDish { set; get; }

        public ICollection<Order> Orders { set; get; }

        public HttpPostedFileBase File { get; set; }


    }
}