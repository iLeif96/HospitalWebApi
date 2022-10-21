using Hospital.Application.Models;
using Hospital.Domain.Common;

namespace Hospital.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : DbEntityBase
    {
        public Task<List<TEntity>> GetAllAsync(bool isUseTracking = false, bool isNeedToUseInclude = true);
        public Task<List<TEntity>> GetPageAsync(PaginationOptions parameters, bool isNeedToUseInclude = true);
        public TEntity? FindById(long id, bool isUseTracking = false, bool isNeedToUseInclude = true);
        public Task<TEntity?> FindByIdAsync(long id, bool isUseTracking = false, bool isNeedToUseInclude = true);
        public Task<TEntity> InsertAsync(TEntity model);
        public Task<TEntity> UpdateAsync(TEntity model);
        public Task<bool> DeleteAsync(long id);
    }
}
