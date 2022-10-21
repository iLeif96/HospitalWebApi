using AutoMapper;

using Hospital.Application.DTO;
using Hospital.Application.Interfaces.Repositories;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.Services.Abstract;
using Hospital.Domain.Entities;

namespace Hospital.Application.Services
{
    public class DoctorsService : CrudServiceBase<Doctor, DoctorDto, DoctorPageDto>, IDoctorsService
    {
        public DoctorsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}
