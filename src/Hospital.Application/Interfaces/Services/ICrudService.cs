namespace Hospital.Application.Interfaces.Services
{
    public interface ICrudService<TDto, TPageDto> where TDto : class where TPageDto : class
    {
        Task<IEnumerable<TPageDto>> Get();
        Task<TDto?> Get(long id);
        Task<IEnumerable<TPageDto>> GetPage(int page, string order, string orderBy);

        Task<TDto> Add(TDto entity);
        Task<TDto> Modify(long id, TDto entity);
        Task<bool> Delete(long id);
    }
}
