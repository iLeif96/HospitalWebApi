using AutoMapper;

using Hospital.Application.DTO;
using Hospital.Application.Interfaces.Repositories;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.Services.Abstract;
using Hospital.Domain.Entities;

namespace Hospital.Application.Services
{
    public class PatientsService : CrudServiceBase<Patient, PatientDto, PatientPageDto>, IPatientsService
    {
        public PatientsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}
