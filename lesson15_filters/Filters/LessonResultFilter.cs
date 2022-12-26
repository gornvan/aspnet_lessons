using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson15_filters.Filters
{
    public class LessonResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var resul = context.Result;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var resul = context.Result;
        }

    }
}
