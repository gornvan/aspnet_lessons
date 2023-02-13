using CQSMediator.Contracts.CQS.Validation;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    internal class CreateTeaValidator : CreateTeaCommand, IValidator
    {
        private readonly CreateTeaCommand _instance;

        public CreateTeaValidator(CreateTeaCommand instance)
        {
            _instance = instance;
        }

        public void Validate()
        {
            if(string.IsNullOrEmpty(_instance.Name)
                || _instance.Name.Length > 200)
            {
                throw new ValidationException("Invalid Tea Name. Must be non-empty and no longer than 200 symbols");
            }
        }
    }
}
