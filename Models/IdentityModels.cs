using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBookingCar.Models.EF;

namespace WebBookingCar.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }

       
        public string Avatar { get; set; }

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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
      
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}