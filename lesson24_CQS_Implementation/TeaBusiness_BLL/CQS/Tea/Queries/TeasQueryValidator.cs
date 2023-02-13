using CQSMediator.Contracts.CQS.Validation;
using TeaBusiness_BLL.CQS.Tea.Queries;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    internal class TeasQueryValidator : TeasQuery, IValidator
    {
        public void Validate()
        {
            if(this.SearchString.Length > 200)
            {
                throw new ValidationException("Invalid SearchString. Must no longer than 200 symbols");
            }
        }
    }
}
