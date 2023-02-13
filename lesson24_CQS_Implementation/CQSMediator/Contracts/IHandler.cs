namespace CQSMediator.Contracts.CQS
{
    public interface IHandlerMarker
    { }

    public interface IHandler<TOut> : IHandlerMarker
    {
        Task<TOut> Execute();
    }
}
