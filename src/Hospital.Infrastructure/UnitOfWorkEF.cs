using Hospital.Application.Interfaces.Repositories;
using Hospital.Domain.Common;
using Hospital.Domain.Entities;
using Hospital.Infrastructure.Databases;
using Hospital.Infrastructure.Repositories;

namespace Hospital.Infrastructure
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private HospitalContext _dbContext;
        private bool _isDisposing;
        private Dictionary<string, object> _repositories;


        public UnitOfWorkEF(HospitalContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<string, object>();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DbEntityBase
        {
            string type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IGenericRepository<TEntity>)_repositories[type];
            }

            IGenericRepository<TEntity> repo;
            if (type == nameof(Doctor))
            {
                repo = (IGenericRepository<TEntity>)new DoctorsRepositoryEF(_dbContext);
            }
            else if (type == nameof(Patient))
            {
                repo = (IGenericRepository<TEntity>)new PatientsRepositoryEF(_dbContext);
            }
            else
            {
                repo = new GenericRepositoryEF<TEntity>(_dbContext);
            }

            _repositories[type] = repo;
            return repo;
        }

        public void Dispose()
        {
            if (_isDisposing)
            {
                return;
            }

            _dbContext.Dispose();

            _isDisposing = true;
        }
    }
}
