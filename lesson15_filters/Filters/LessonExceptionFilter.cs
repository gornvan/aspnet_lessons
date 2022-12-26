using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson15_filters.Filters
{
    public class LessonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
        }
    }
}
