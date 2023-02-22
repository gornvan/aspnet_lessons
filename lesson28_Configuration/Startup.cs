using lesson28_Configuration.ConfigModels;

namespace lesson28_Configuration
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appConfig = configuration.Get<ApplicationConfig>();

            if(appConfig == null || appConfig.EncryptionConfig == null || appConfig.PayPalAccounts == null) {
                throw new NullReferenceException("Configuration not found, exiting.");
            }


            // immutable way: re-initialize configuration object on every run
            services.AddTransient<EncryptionConfig>((IServiceProvider provider) => new EncryptionConfig
            {
                EncryptionKey = appConfig.EncryptionConfig.EncryptionKey,
            });

            // mutable way: register configration as singleton
            services.AddSingleton(appConfig.PayPalAccounts);
        }

    }
}
