using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson15_filters.Filters
{
    public class LessonAuthorizationFilter : IAuthorizationFilter
    {
        public LessonAuthorizationFilter(IConfiguration configuration)
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // set context Result to abort the whole execution and return it:
            // context.Result = new NotFoundResult();
        }
    }
}
