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

        public Dish EditDish(Dish _dish)
        {
            Dish dish = FindDishById(_dish.Id);
            dish.Name = _dish.Name;
            dish.PathImg = dish.PathImg;
            dish.Cost = _dish.Cost;
            dish.Description = _dish.Description;
            dish.TypeDish = _dish.TypeDish;
            dish.Weight = _dish.Weight;
            context.SaveChanges();
            return dish;
        }




        public void DeleteDish(Dish _dish)
        {
            context.Dishes.Remove(FindDishById(_dish.Id));
            context.SaveChanges();
        }

        public IEnumerable<Dish> GelAllDishes()
        {
            return context.Dishes.ToList();
        }

        public Dish FindDishById(int Id) => context.Dishes.FirstOrDefault(x => x.Id == Id);

        
    }

}