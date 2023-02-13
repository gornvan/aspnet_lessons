namespace CQSMediator.Contracts.CQS.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
