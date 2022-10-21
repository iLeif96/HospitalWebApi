
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.DTO;
using Hospital.WebApi.Controllers;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : HospitalControllerBase<PatientDto, PatientPageDto>
    {
        public PatientsController(IPatientsService patientsService) : base(patientsService)
        {

        }
    }
}
