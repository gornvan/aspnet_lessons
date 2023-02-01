namespace TeaBusiness_BLL.Contracts.CQS.Validation
{
    internal class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
