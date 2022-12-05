using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TireServiceDBContext : DbContext
    {
        public TireServiceDBContext(DbContextOptions<TireServiceDBContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Tire> Tires { get; set; }
    }
}
