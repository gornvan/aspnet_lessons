using CQSMediator.Contracts.CQS.Validation;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    internal class CreateTeaValidator : CreateTeaCommand, IValidator
    {
        public void Validate()
        {
            if(string.IsNullOrEmpty(this.Name)
                || this.Name.Length > 200)
            {
                throw new ValidationException("Invalid Tea Name. Must be non-empty and no longer than 200 symbols");
            }
        }
    }
}
