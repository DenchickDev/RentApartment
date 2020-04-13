using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RentApartment.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<TypeHome> TypesHome { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}