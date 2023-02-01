namespace TeaBusiness_BLL.Contracts.CQS
{
    internal interface IExecutable<TOut>
    {
        Task<TOut> Execute();
    }
}
