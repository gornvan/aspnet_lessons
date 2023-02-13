namespace CQSMediator.Contracts.Exceptions
{
    internal class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(string? commandOrQueryTypeName) 
            : base($@"Could not found Handler for command or query '{commandOrQueryTypeName}'")
        { }
    }
}
