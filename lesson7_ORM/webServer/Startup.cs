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

            var dbcontext = ConfigureDBContext(config);

            services.AddTransient<ICarService, CarService>();
        }

        private static TireServiceDBContext ConfigureDBContext(IConfiguration config)
        {
            config.GetConnectionString("ConnectionString_TireService");

            var context = new TireServiceDBContext("(carsDB).");
            return context;
        }
    }       
}           
