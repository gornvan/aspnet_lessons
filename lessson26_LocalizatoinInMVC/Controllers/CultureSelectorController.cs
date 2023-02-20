using lessson26_LocalizatoinInMVC.Localization;
using Microsoft.AspNetCore.Mvc;

namespace lessson26_LocalizatoinInMVC.Controllers
{
    public class CultureSelectorController : Controller
    {
        [HttpGet]
        public IActionResult Index(string culture)
        {
            if (SupportedCultures.SupportedCulturesIds.Contains(culture))
            {
                Response.Cookies.Delete("Culture");

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.MaxAge = TimeSpan.FromDays(14);
                Response.Cookies.Append("Culture", culture, cookieOptions);
            }
            
            var referer = Request.Headers.Referer;

            return Redirect(referer);
        }
    }
}
