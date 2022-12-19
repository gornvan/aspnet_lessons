using lesson13_Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace lesson13_Security
{
    public class TireServiceDBContext : DbContext
    {
        public TireServiceDBContext(DbContextOptions<TireServiceDBContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Tire> Tires { get; set; }
    }
}
