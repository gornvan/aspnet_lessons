namespace CQSMediator.Contracts.Exceptions
{
    internal class ValidatorNotFoundException : Exception
    {
        public ValidatorNotFoundException(string? commandOrQueryTypeName)
            : base($@"Could not found Validator for command or query '{commandOrQueryTypeName}'")
        { }
    }
}
