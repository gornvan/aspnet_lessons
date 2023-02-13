using CQSMediator.Contracts.CQS.Validation;
using TeaBusiness_BLL.CQS.Tea.Queries;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    internal class TeasQueryValidator : TeasQuery, IValidator
    {
        private readonly TeasQuery _instance;

        public TeasQueryValidator(TeasQuery instance)
        {
            _instance = instance;
        }

        public void Validate()
        {
            if(_instance.SearchString.Length > 200)
            {
                throw new ValidationException("Invalid SearchString. Must no longer than 200 symbols");
            }
        }
    }
}
