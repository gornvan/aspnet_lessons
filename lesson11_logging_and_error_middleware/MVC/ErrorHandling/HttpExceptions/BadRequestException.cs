namespace lesson11_serilog.ErrorHandling.HttpExceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string? message, string argumentName)
            : base($"{message} (argument: {argumentName})")
        {
        }
    }
}
