
using Hospital.Application.DTO.Abstract;
using Hospital.Application.Interfaces.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [ApiController]
    public abstract class HospitalControllerBase<TDto, TPageDto> : ControllerBase
        where TDto : DtoBase where TPageDto : DtoBase
    {
        protected ICrudService<TDto, TPageDto> _crudService;

        public HospitalControllerBase(ICrudService<TDto, TPageDto> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        [Route("GetAll")]
        public virtual async Task<ActionResult<IEnumerable<TPageDto>>> Get()
        {
            IEnumerable<TPageDto> result = await _crudService.Get();

            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public virtual async Task<ActionResult<IEnumerable<TDto>>> Get(long id)
        //{
        //    TDto? result = await _crudService.Get(id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<ActionResult> GetPage(int page, string order, string orderBy)
        {
            IEnumerable<TPageDto> pageResult = await _crudService.GetPage(page, order, orderBy);

            return Ok(pageResult);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            TDto entityResult = await _crudService.Add(dto);

            if (entityResult == null)
            {
                return Problem("Object not added");
            }

            return Ok(entityResult);
        }

        [HttpPut]
        public async Task<ActionResult> Put(long id, [FromBody] TDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            TDto entityResult = await _crudService.Modify(id, dto);

            if (entityResult == null)
            {
                return Problem("Object is not modified");
            }

            return Ok(entityResult);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            bool deleteResult = await _crudService.Delete(id);

            if (deleteResult == false)
            {
                return Problem("Problem during deletion");
            }

            return Ok(deleteResult);
        }
    }
}
