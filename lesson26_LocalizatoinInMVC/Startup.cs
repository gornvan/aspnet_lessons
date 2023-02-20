using lessson26_LocalizatoinInMVC.Localization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace lessson26_LocalizatoinInMVC
{
    public static class Startup
    {
        public static void RegisterLocaleProvider(IServiceCollection services, IConfiguration config)
        {

            services.AddLocalization(options => options.ResourcesPath = "Localization/Translations");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = SupportedCultures.SupportedCulturesIds
                    .Select(cid => new CultureInfo(cid)).ToList();

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.DefaultRequestCulture =
                    new RequestCulture(
                        culture: SupportedCultures.EnUSCulture,
                        uiCulture: SupportedCultures.EnUSCulture
                        );

                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                {
                    // My custom request culture logic
                    var cultureFromCookies = context.Request.Cookies["Culture"];
                    if (cultureFromCookies != null)
                    {
                        if (SupportedCultures.SupportedCulturesIds.Contains(cultureFromCookies))
                        {
                            return await Task.FromResult(new ProviderCultureResult(cultureFromCookies));
                        }
                    }
                    return null;
                }));
            });
        }
    }
}
