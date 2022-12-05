using DAL;
using lesson6.Business.Contract.Interfaces;
using lesson6.Business.Services;
using Microsoft.EntityFrameworkCore;

namespace lesson6
{
    internal static class Startup
    {
        public const string ConnectionStringName = "ConnectionString_TireService";

        public static void GatherServices(IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddMvcCore().AddRazorViewEngine();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ConfigureDBContext(services, config);

            services.AddTransient<ICarService, CarService>();
        }

        private static void ConfigureDBContext(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString(ConnectionStringName);
            
            services.AddDbContext<TireServiceDBContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }


        public static void MigrateDB(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TireServiceDBContext>();

                if(dbContext == null)
                {
                    throw new SystemException("This should never happen, the DbContext couldn't recolve!");
                }

                dbContext.Database.Migrate();
            }
        }
    }
}
