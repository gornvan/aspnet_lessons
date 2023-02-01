using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.Contracts.DAL
{
    /// <summary>
    /// On exiting out of Procedure (Scope) - IDisposable must call Dispose on DataContext
    /// OR trigger SaveChanges on the underlying DataContext
    /// </summary>
    public interface ITeaBusinessUnitOfWork : IDisposable
    {
        IRepository<TModel, Tid> GetRepository<TModel, Tid>() where TModel : EntityBase<Tid>, new();

        Task<int> SaveChangesAsync();
    }
}
