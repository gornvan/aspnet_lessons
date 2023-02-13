using CQSMediator.Contracts.CQS;

namespace TeaBusiness_BLL.CQS.Tea.Queries
{
    internal class TeasQuery: IQuery
    {
        public string SearchString { get; set; } = "";
    }
}
