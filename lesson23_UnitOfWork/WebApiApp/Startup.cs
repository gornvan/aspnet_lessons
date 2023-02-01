
using TeaBusiness_BLL.Contracts;
using TeaBusiness_BLL.Contracts.DAL;
using TeaBusiness_DAL;
using TeaBusiness_DAL.UoW;

namespace WebApiApp
{
    public static class Startup
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITeaBusinessUnitOfWork, TeaBusinessUnitOfWork>();

            TeaBusiness_DAL.Module.RegisterServices(services, configuration);

            TeaBusiness_BLL.Module.RegisterServices(services, configuration);

# if DEBUG
            DebugChecks(services);
#endif
        }


        private static void DebugChecks(IServiceCollection services)
        {
            //debug - time checks:
            var transientServicet = services.Where(s => s.Lifetime == ServiceLifetime.Transient).ToList();
            var provider = services.BuildServiceProvider();
            var teaStorageServies = provider.GetService<ITeaStorageService>();

            var dbContext = provider.GetService<TeaBusinessDbContext>();
        }
    }
}
