using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Routing.Models;

namespace MVC_html_helpers.Helpers
{
    public static class CatAgeCalculator
    {
        public static HtmlString RenderAge(this IHtmlHelper html, int yearOfBirth)
        {
            var currentYear = DateTime.Now.Year;
            var age = currentYear - yearOfBirth;
            var render = new HtmlString(
                    $"<span style=\"color: #aaa\">({age}) </span>"
                );

            return render;
        }

        public static HtmlString RenderAgeSpecificallyForCats(this IHtmlHelper<CatViewModel> html)
        {
            var birthYear = html.ViewData.Model.BirthYear;
            var currentYear = DateTime.Now.Year;
            var age = currentYear - birthYear;
            var render = new HtmlString(
                $"<span style=\"color: #aaa\">({age}) </span>"
                );

            return render;
        }
    }
}
