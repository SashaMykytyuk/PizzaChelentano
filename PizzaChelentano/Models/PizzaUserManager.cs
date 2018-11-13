using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace PizzaChelentano.Models
{
    public class PizzaUserManager : UserManager<PizzaUser>
    {
        public PizzaUserManager(IUserStore<PizzaUser> store)
            : base(store)
        {
        }
        public static PizzaUserManager Create(IdentityFactoryOptions<PizzaUserManager> options,
            IOwinContext context)
        {
            PizzaContext db = context.Get<PizzaContext>();
            PizzaUserManager manager = new PizzaUserManager(new UserStore<PizzaUser>(db));
            return manager;
        }
    }
}