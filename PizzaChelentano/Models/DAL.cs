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
            return FindDishById(dish.Id);

        }

        public IEnumerable<Dish> GelAllDishes()
        {
            return context.Dishes.ToList();
        }

        public Dish FindDishById(int Id) => context.Dishes.FirstOrDefault(x => x.Id == Id);

        
    }

}