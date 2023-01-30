
using Microsoft.EntityFrameworkCore;
using TeaBusiness_BLL.Contracts.Models;
using TeaBusiness_DAL.Repository;

namespace TeaBusiness_DAL.UoW
{
    public class TeaBusinessUnitOfWork : ITeaBusinessUnitOfWork
    {
        private readonly DbContext _dbContext;

        public TeaBusinessUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<TModel, Tid> GetRepository<TModel, Tid>() where TModel : EntityBase<Tid>, new()
        {
            return new Repository<TModel, Tid>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
