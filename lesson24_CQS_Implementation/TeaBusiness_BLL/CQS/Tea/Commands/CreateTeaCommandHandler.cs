using CQSMediator.Contracts.CQS;
using TeaBusiness_BLL.Contracts.DAL;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.CQS.Tea.Commands
{
    public class CreateTeaCommandHandler : CreateTeaCommand, IExecutable<TeaModel>
    {
        private ITeaBusinessUnitOfWork _unitOfWork;

        public CreateTeaCommandHandler(ITeaBusinessUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TeaModel> Execute()
        {
            var repo = _unitOfWork.GetRepository<TeaModel, long>();
            var teamodel = new TeaModel
            {
                Name = this.Name,
            };
            var entityEntry = repo.Add(teamodel);

            await _unitOfWork.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
