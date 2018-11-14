﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaChelentano.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Cost { set; get; }
        public string Weight { set; get; }
        public string TypeDish { set; get; }
        public string PathImg { set; get; }

        public ICollection<Order> Orders { set; get; }
    }
}