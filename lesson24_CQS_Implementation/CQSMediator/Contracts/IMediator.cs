using CQSMediator.Contracts.CQS;

namespace CQSMediator.CQS
{
    public interface IMediator
    {
        /// <summary>
        /// Execute Command or Query.
        /// </summary>
        Task<Tout> Process<TExecutable, Tout>(TExecutable executable) where TExecutable : IExecutable<Tout>;

        /// <summary>
        /// Just a more common name for "Process"
        /// </summary>
        Task<Tout> Send<TExecutable, Tout>(TExecutable executable) where TExecutable : IExecutable<Tout>
        {
            return Process<TExecutable, Tout>(executable);
        }
    }
}
