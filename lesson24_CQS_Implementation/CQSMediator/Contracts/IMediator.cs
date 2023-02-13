using CQSMediator.Contracts.CQS;

namespace CQSMediator.CQS
{
    public interface IMediator
    {
        /// <summary>
        /// Execute Command or Query.
        /// </summary>
        Task<object> Process(IQuery queryDto);

        /// <summary>
        /// Just a more common name for "Process"
        /// </summary>
        Task<object> Process(ICommand commandDto);
    }
}
