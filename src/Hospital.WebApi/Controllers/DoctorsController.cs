
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital.Application.Interfaces.Services;
using Hospital.Application.DTO;
using Hospital.WebApi.Controllers;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DoctorsController : HospitalControllerBase<DoctorDto, DoctorPageDto>
    {
        public DoctorsController(IDoctorsService doctorsService) : base(doctorsService)
        {

        }
    }
}
