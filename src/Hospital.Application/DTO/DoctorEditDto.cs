using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using Hospital.Application.DTO.Abstract;

namespace Hospital.Application.DTO
{
    public class DoctorDto : DtoBase
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Office id")]
        public long OfficeId { get; set; }

        [Display(Name = "Specialization id")]
        public long SpecializationId { get; set; }

        [Display(Name = "District id")]
        public long? DistrictId { get; set; }
    }
}
