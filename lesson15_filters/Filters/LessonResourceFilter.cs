using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson15_filters.Filters
{
    public class LessonResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var result = context.Result;
        }
    }
}
