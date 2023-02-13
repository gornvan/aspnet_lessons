using CQSMediator.Contracts.CQS;
using Microsoft.EntityFrameworkCore;
using TeaBusiness_BLL.Contracts.DAL;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_BLL.CQS.Tea.Queries
{
    internal class TeasQeuryHandler : TeasQuery, IExecutable<List<TeaModel>>
    {

        private readonly ITeaBusinessUnitOfWork _unitOfWork;

        public TeasQeuryHandler(ITeaBusinessUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<TeaModel>> Execute()
        {
            var repo = _unitOfWork.GetRepository<TeaModel, long>();

            IQueryable<TeaModel> query = repo.AsQueriable().Include(t => t.StoragesStoring);

            if (!string.IsNullOrEmpty(this.SearchString)) {
                query = query.Where(t => t.Name.Contains(this.SearchString, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToListAsync();
        }
    }
}
