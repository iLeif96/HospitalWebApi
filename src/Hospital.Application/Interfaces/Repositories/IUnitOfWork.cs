using Hospital.Domain.Common;

namespace Hospital.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DbEntityBase;
    }
}
