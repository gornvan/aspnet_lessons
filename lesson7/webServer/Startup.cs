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

            services.AddSingleton<IForeverService, ForeverService>();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ITireService, OneShotService>();

            services.AddScoped<IRequestAccontingService, RequestAccontingService>();
        }

        public static TireServiceDBContext ConfigureDBContext()
        {
            // todo take connectionString

            var context = new TireServiceDBContext("(carsDB).");
            return context;
        }
    }       
}           
