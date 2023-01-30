using TeaBusiness_DAL.UoW;

namespace WebApiApp
{
    public static class Startup
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TeaBusinessDbContext>();
            
            services.AddScoped<ITeaBusinessUnitOfWork, TeaBusinessUnitOfWork>();



            TeaBusiness_BLL.Module.RegisterServices(services, configuration);
            // debug-time checks:
            //var transientServicet = services.Where(s => s.Lifetime == ServiceLifetime.Transient).ToList();
            //var teaStorageServies = services.BuildServiceProvider().GetService<ITeaStorageService>();
            

        }
    }
}
