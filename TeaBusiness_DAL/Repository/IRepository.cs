using Microsoft.EntityFrameworkCore.ChangeTracking;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_DAL.Repository
{
    public interface IRepository<TModel, Tid> where TModel : EntityBase<Tid>
    {
        EntityEntry<TModel> Add(TModel model);

        ValueTask<TModel?> Find(Tid id);

        /// <summary>
        /// the model must have its Id set for update to function
        /// </summary>
        EntityEntry<TModel> Update(TModel model);

        void Delete(Tid id);

        /// <summary>
        /// Entity-Framework-specific assumption that AsQueriable is available on DataStorage provider
        /// </summary>
        IQueryable<TModel> AsQueriable();
    }
}
