using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YatriSewa_MVC.Models
{
    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        // DbSet properties for your application entities
        public DbSet<LoginUser> UserLogin { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TransactionReport> TransactionReports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}




//namespace YatriSewa_MVC.Models
//{
//    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
//    {
//        public DbSet<LoginUser> Login_Detail{ get; set; }
        
//        public DbSet<Customer> Customer { get; set; }

//        public DbSet<Bus> Bus { get; set; }

//        public DbSet<Driver> Drivers{ get; set; }

//        public DbSet<Payment> Payment { get; set; }

//        public DbSet<TransactionReport> TransactionReport { get; set; }

//        public DbSet<Order> Order { get; set; }

//        public DbSet<Reservation> Reservation { get; set; }
//    }
//}
