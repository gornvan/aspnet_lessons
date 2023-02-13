namespace CQSMediator.Contracts.CQS
{
    public interface IExecutable<TOut>
    {
        Task<TOut> Execute();
    }
}
