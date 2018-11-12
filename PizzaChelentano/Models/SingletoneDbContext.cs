using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaChelentano.Models
{
    public class SingletoneDbContext
    {
        public string Name { get; private set; }

        private SingletoneDbContext()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static PizzaContext GetInstance()
        {
            return Nested.instance;
        }

        private class Nested
        {
            internal static readonly PizzaContext instance = new PizzaContext();
        }
    }
}