using TeaBusiness_BLL.Contracts;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Services
{
    public class TeaService : TransientServiceBase, ITeaService
    {
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
