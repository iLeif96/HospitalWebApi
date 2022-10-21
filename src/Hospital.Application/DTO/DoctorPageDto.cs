using System.ComponentModel.DataAnnotations;

using Hospital.Application.DTO.Abstract;

namespace Hospital.Application.DTO
{
    public class DoctorPageDto : DtoBase
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Office Number")]
        public string Office { get; set; }

        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        [Display(Name = "District")]
        public string? District { get; set; }
    }
}
