namespace lesson11_serilog.ErrorHandling.HttpExceptions
{
    public class HttpException : Exception
    {
        public HttpException(string? message) : base(message)
        {
        }
    }
}
