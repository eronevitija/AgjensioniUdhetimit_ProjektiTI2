using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AgjensioniUdhetimit_ProjektiTI2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
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
            : base("agjensioniConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); 
        //    modelBuilder.Entity<Booking>().Property(b => b.DayOfStaying).IsRequired();
        //    modelBuilder.Entity<Booking>().Property(b => b.HotelName).IsRequired();
        //    modelBuilder.Entity<Booking>().Property(b => b.NumberOfRooms).IsRequired();
            

        //}

        public System.Data.Entity.DbSet<AgjensioniUdhetimit_ProjektiTI2.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<AgjensioniUdhetimit_ProjektiTI2.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<AgjensioniUdhetimit_ProjektiTI2.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<AgjensioniUdhetimit_ProjektiTI2.Models.Booking> Bookings { get; set; }
    }
}