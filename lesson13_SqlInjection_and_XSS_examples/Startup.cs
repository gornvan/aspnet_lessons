using Microsoft.EntityFrameworkCore;

namespace lesson13_Security
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
            }

            private static void ConfigureDBContext(IServiceCollection services, IConfiguration config)
            {
                var connectionString = config.GetConnectionString(ConnectionStringName);

                services.AddDbContext<TireServiceDBContext>(options => {
                    options.UseSqlServer(connectionString);
                });
            }
        }
}
