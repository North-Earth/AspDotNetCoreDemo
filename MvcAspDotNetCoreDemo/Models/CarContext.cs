using Microsoft.EntityFrameworkCore;

namespace MvcAspDotNetCoreDemo.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
