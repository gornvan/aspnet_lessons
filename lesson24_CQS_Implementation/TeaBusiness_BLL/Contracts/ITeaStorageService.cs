using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Contracts
{
    public interface ITeaStorageService
    {
        Task<StorageModel> CreateStorage();

        Task DeleteStorage();

        Task<IEnumerable<TeaModel>> AddTeaToStorage();
    }
}
