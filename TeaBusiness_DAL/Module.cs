using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TeaBusiness_DAL
{
    public class Module
    {
        public static void RegisterServices(IServiceCollection servicesContainer, IConfiguration configuration)
        {
            servicesContainer.AddDbContext<TeaBusinessDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
        }
    }
}
