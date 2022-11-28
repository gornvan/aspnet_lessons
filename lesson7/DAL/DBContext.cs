using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TireServiceDBContext : DbContext
    {
        public TireServiceDBContext(string connectionString) : base()
        {
            this.Database.SetConnectionString(connectionString);

            this.Database.EnsureCreated();
        }



        public DbSet<Car> Cars { get; set; }
        public DbSet<Tire> Tires { get; set; }
    }
}
