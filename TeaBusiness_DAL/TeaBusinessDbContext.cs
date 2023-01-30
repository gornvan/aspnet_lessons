using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TeaBusiness_DAL
{
    public class TeaBusinessDbContext : DbContext
    {
        public TeaBusinessDbContext(DbContextOptions<TeaBusinessDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
