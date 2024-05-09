using Microsoft.EntityFrameworkCore;
namespace YatriSewa_MVC.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Yatris { get; set; }

        public UserContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
