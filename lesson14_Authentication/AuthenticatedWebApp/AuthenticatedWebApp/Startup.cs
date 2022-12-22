using AuthenticatedWebApp.Data.Seed;

namespace AuthenticatedWebApp
{
    public class Startup
    {
        /// <summary>
        /// call this AFTER registering the identity providers AND migrating the DB
        /// </summary>
        /// <param name="services"></param>
        public static async Task InitializeIdentities(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var identitySeeder = scope.ServiceProvider.GetService<CreateDefaultUserService>();
                await identitySeeder.CreateRoles();
            }
        }
    }
}
