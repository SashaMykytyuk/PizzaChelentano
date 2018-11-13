using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PizzaChelentano.Models
{
    public class PizzaContext: IdentityDbContext<PizzaUser>
    {
        public PizzaContext() : base("PizzaDb")
        {
           
        }

        public static PizzaContext Create()
        {
            return new PizzaContext();
        }

        //public virtual DbSet<PizzaUser> PizzaUsers { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Dish> Dishes { set; get; }

        public System.Data.Entity.DbSet<PizzaChelentano.Areas.Administration.Models.UserForAdmin> UserForAdmins { get; set; }
    }
}