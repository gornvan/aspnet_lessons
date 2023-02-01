using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Contracts
{
    public interface ITeaService
    {
        Task<TeaModel> AddTea();

        Task DeleteTea();
    }
}
