using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using Hospital.Application.DTO.Abstract;

namespace Hospital.Application.DTO
{
    public class PatientPageDto : DtoBase
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Display(Name = "District id")]
        public string District { get; set; }
    }
}
