namespace lesson11_serilog.ErrorHandling.HttpExceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
