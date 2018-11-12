using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaChelentano.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? DateStart { get; set; }
        public bool Sate { set; get; }

        public virtual ICollection<Dish> Dishes { set; get; }
        public virtual ICollection<PizzaUser> PizzaUsers { set; get; }
    }
}