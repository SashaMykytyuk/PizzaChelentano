using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PizzaChelentano.Models
{
    public class PizzaUser:IdentityUser
    {
        public string Discount { set; get; }
        public string Street { set; get; }
        public string House { set; get; }
        public string NumberApartment { set; get; }
        public string Role { set; get; }
        public DateTime TimeRegistration { get; set; }

        public virtual ICollection<Order> Orders { set; get; }

        public PizzaUser()
        {
            Role = "user";
        }
    }
}