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
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Service> Services { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<TransactionReport> TransactionReports { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.Service)
                .WithOne(s => s.Bus)
                .HasForeignKey<Service>(s => s.BusId);

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.Operator)
                .WithMany(o => o.Buses)
                .HasForeignKey(b => b.OperatorId);
        }
    }
}

