namespace lesson11_serilog.ErrorHandling.HttpExceptions
{
    public class InternalErrorExcetion : HttpException
    {
        public InternalErrorExcetion(string? message) : base(message)
        {
        }
    }
}
