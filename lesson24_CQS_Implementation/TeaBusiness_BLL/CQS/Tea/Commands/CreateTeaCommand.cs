using CQSMediator.Contracts.CQS;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    public class CreateTeaCommand : ICommand
    {
        public string Name { get; set; } = "";
    }
}
