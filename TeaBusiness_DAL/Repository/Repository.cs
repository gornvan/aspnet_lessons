using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TeaBusiness_BLL.Contracts.DAL;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_DAL.Repository
{
    public class Repository<TModel, Tid> : IRepository<TModel, Tid> where TModel : EntityBase<Tid>, new()
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EntityEntry<TModel> Add(TModel model)
        {
            var attachedModel = _dbContext
                .Set<TModel>()
                .Add(model);

            return attachedModel;
        }

        public IQueryable<TModel> AsQueriable()
        {
            return _dbContext.Set<TModel>().AsQueryable();
        }

        public void Delete(Tid id)
        {
            var model = new TModel() { Id = id };
            var attachedModel = _dbContext.Attach(model);
            _dbContext.Remove(attachedModel);
        }

        public ValueTask<TModel?> Find(Tid Id)
        {
            return _dbContext.Set<TModel>().FindAsync(Id);
        }

        /// <summary>
        /// after calling Update, NEVER change any values insice model,
        /// unless You want some more changes to be applied on SaveChanges
        /// </summary>
        public EntityEntry<TModel> Update(TModel model)
        {
            var attachedModel = _dbContext.Attach(model);
            attachedModel.State = EntityState.Modified;
            return attachedModel;
        }
    }
}
