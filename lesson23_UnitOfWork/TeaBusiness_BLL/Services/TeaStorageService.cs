using TeaBusiness_BLL.Contracts;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Services
{
    public class TeaStorageService : TransientServiceBase, ITeaStorageService
    {
        private ITeaService _teaService;

        public TeaStorageService(ITeaService teaService) { 
            _teaService = teaService;
        }

        public Task<IEnumerable<TeaModel>> AddTeaToStorage()
        {
            throw new NotImplementedException();
        }

        public Task<StorageModel> CreateStorage()
        {
            throw new NotImplementedException();
        }

        public Task DeleteStorage()
        {
            throw new NotImplementedException();
        }
    }
}
