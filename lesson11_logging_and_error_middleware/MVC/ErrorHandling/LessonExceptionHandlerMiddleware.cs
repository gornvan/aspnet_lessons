using lesson11_serilog.ErrorHandling.HttpExceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace lesson11_serilog.ErrorHandling
{
    public class LessonExceptionHandlerMiddleware
    {
        private readonly Serilog.ILogger _logger;

        public LessonExceptionHandlerMiddleware(Serilog.ILogger logger) {
            _logger = logger.ForContext<LessonExceptionHandlerMiddleware>();
        }

        public async Task HandleException(HttpContext context)
        {
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature == null)
            {
                await context.Response.WriteAsync(ErrorPages.InternalErrorPage);
                return;
            }

            string responseText = string.Empty;

            var ex = exceptionHandlerPathFeature.Error.InnerException;
            switch (ex)
            {
                case NotFoundException:
                    _logger.Information($@"returning Not Found 404: {ex.Message}");
                    context.Response.StatusCode = 404;
                    responseText = ErrorPages.NotFoundPage;
                    break;

                case BadRequestException:
                    _logger.Warning($@"returning Bad Request 400: {ex.Message}");
                    context.Response.StatusCode = 400;
                    responseText = ConstructBadRequestErrorPage((BadRequestException)ex);
                    break;

                case InternalErrorExcetion:
                    _logger.Error(ex, $@"returning Internal Error 500: {ex.Message}");
                    context.Response.StatusCode = 500;
                    responseText =  ErrorPages.InternalErrorPage;
                    break;
            }

            await context.Response.WriteAsync(responseText);
        }


        private static string ConstructBadRequestErrorPage(BadRequestException ex)
        {
            return ErrorPages.BadRequestPageTemplate.Replace(
                "{Message}",
                ex.Message
            );
        }
    }
}
