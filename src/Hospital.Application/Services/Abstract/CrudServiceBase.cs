using AutoMapper;

using Hospital.Application.DTO.Abstract;
using Hospital.Application.Interfaces.Repositories;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.Models;
using Hospital.Domain.Common;

namespace Hospital.Application.Services.Abstract
{
    public abstract class CrudServiceBase<TEntity, TDto, TPageDto> : ICrudService<TDto, TPageDto>
        where TEntity : DbEntityBase where TDto : DtoBase where TPageDto : DtoBase
    {
        protected IUnitOfWork _unitOfWork;
        protected IGenericRepository<TEntity> _repository;
        protected IMapper _mapper;

        protected CrudServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task<TDto> Add(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            var response = await _repository.InsertAsync(entity);

            if (response == null)
            {
                return null;
            }

            return _mapper.Map<TDto>(response);
        }

        public virtual async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<TDto> Modify(long id, TDto dto)
        {
            var entity = await _repository.FindByIdAsync(id);

            if (entity == null)
            {
                return null;
            }

            entity = _mapper.Map<TDto, TEntity>(dto);
            entity.Id = id;

            var response = await _repository.UpdateAsync(entity);
            if (response == null)
            {
                return null;
            }

            var responsedDto = _mapper.Map<TDto>(response);

            return responsedDto;
        }

        public virtual async Task<IEnumerable<TPageDto>> Get()
        {
            var response = await _repository.GetAllAsync();

            var dtoPages = response.Select(ent => _mapper.Map<TPageDto>(ent));

            return dtoPages;
        }

        public virtual async Task<TDto?> Get(long id)
        {
            var response = await _repository.FindByIdAsync(id);

            if (response == null)
            {
                return null;
            }

            var dto = _mapper.Map<TDto>(response);

            return dto;
        }

        public virtual async Task<IEnumerable<TPageDto>> GetPage(int page, string order, string orderBy)
        {
            PaginationOptions options = new PaginationOptions(page, order, orderBy);

            var response = await _repository.GetPageAsync(options);

            var dtoPages = response.Select(ent => _mapper.Map<TPageDto>(ent));

            return dtoPages;
        }
    }
}
