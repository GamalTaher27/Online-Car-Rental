using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System;
using System.Linq;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public string Fname { get; set; }
        
        public string Lname { get; set; }
        
        public string Usname { get; set; }
        public string CarType { get; set; }
        public double Balance { get; set; }
        public int State { get; set; }

        public ActionResult Index()
        {
            return View(db.RoleViewModels.ToList());
        }

        private ActionResult View(object p)
        {
            throw new NotImplementedException();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RentCar.Models.Cars> Cars { get; set; }

        public System.Data.Entity.DbSet<RentCar.Models.Rent> Rents { get; set; }

        public System.Data.Entity.DbSet<RentCar.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.RegisterViewModel> RegisterViewModels { get; set; }

    }
}