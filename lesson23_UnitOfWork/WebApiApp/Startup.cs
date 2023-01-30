
using TeaBusiness_BLL.Contracts;

namespace WebApiApp
{
    public static class Startup
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            TeaBusiness_BLL.Module.RegisterServices(services, configuration);

            var transientServicet = services.Where(s => s.Lifetime == ServiceLifetime.Transient).ToList();

            var teaStorageServies = services.BuildServiceProvider().GetService<ITeaStorageService>();
            
        }
    }
}
