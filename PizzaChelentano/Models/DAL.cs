using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaChelentano.Models
{
    public class DAL
    {
        private readonly PizzaContext context = SingletoneDbContext.GetInstance();
        public Dish CreateDish(Dish dish)
        {

            context.Dishes.Add(dish);
            context.SaveChanges();
            return FindDishByName(dish.Name);

        }

        public Dish FindDishByName(string name) => context.Dishes.FirstOrDefault(x => x.Name == name);
    }

}