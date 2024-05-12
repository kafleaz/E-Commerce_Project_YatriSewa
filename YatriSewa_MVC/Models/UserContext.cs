using Microsoft.EntityFrameworkCore;
namespace YatriSewa_MVC.Models
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<LoginUser> Login_Detail{ get; set; }
        
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Bus> Bus { get; set; }

        public DbSet<Driver> Drivers{ get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<TransactionReport> TransactionReport { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Reservation> Reservation { get; set; }
    }

}
