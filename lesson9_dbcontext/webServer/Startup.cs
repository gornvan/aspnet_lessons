using DAL;
using lesson6.Business.Contract.Interfaces;
using lesson6.Business.Services;
using Microsoft.EntityFrameworkCore;

namespace lesson6
{
    internal static class Startup
    {
        public static void GatherServices(IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ConfigureDBContext(services, config);

            services.AddTransient<ICarService, CarService>();
        }

        private static void ConfigureDBContext(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("ConnectionString_TireService");
            
            services.AddDbContext<TireServiceDBContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }
    }       
}           
