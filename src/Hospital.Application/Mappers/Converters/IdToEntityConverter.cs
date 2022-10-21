using AutoMapper;

using Hospital.Application.Interfaces.Repositories;
using Hospital.Domain.Common;

namespace Hospital.Application.Mappers.Converters
{
    public class IdToEntityConverter<TEntity> : IValueConverter<long?, TEntity> where TEntity : DbEntityBase
    {
        private IUnitOfWork _unitOfWork;

        public IdToEntityConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TEntity Convert(long? id, ResolutionContext context)
        {
            if (id == null)
            {
                return null;
            }

            string tName = typeof(TEntity).Name;
            var repo = _unitOfWork.GetRepository<TEntity>();

            if (repo == null)
            {
                throw new Exception($"Can`t find repository for <{tName}> entity.");
            }

            var result = repo.FindById(id.Value, true);

            if (result == null)
            {
                throw new Exception($"Can`t find <{tName}> entity with id: \"{id}\"");
            }

            return result;
        }
    }
}
