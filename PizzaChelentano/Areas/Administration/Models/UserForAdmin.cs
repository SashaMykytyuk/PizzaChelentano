using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaChelentano.Models;

namespace PizzaChelentano.Areas.Administration.Models
{
    public class UserForAdmin
    {
        public string Id { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Street { set; get; }
        public string House { set; get; }
        public string NumberApartment { set; get; }
        public string Discount { set; get; }
        public string Role { set; get; }
        public IEnumerable<Order> Orders { set; get; }
    }
}