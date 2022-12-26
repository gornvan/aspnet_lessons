using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson15_filters.Filters
{
    public class LessonActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var result = context.Result;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
        }

    }
}
