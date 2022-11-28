using DAL;
using lesson6.Business.Contract.Interfaces;
using lesson6.Business.Services;
using Microsoft.EntityFrameworkCore;

namespace lesson6
{
    internal static class Startup
    {
        public static void GatherServices( IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddTransient<ICarService, CarService>();
        }

        public static TireServiceDBContext ConfigureDBContext()
        {
            // todo take connectionString

            var context = new TireServiceDBContext("(carsDB).");
            return context;
        }
    }       
}           
