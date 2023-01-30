using TeaBusiness_BLL.Contracts;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Services
{
    public class TeaService : TransientServiceBase, ITeaService
    {
        private ITeaBusinessUnitOfWork _unitOfWork;

        public TeaService(ITeaBusinessUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public Task<TeaModel> AddTea()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTea()
        {
            throw new NotImplementedException();
        }
    }
}
