using lesson6.Business.Contract.Interfaces;
using lesson6.Business.Services;

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

            services.AddTransient<IActionService, ActionService>();
            services.AddTransient<IOneShotService, OneShotService>();

            services.AddScoped<IRequestAccontingService, RequestAccontingService>();
        }
    }       
}           
