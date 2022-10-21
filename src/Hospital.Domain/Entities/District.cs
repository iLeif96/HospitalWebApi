using Hospital.Domain.Common;

namespace Hospital.Domain.Entities
{
    public class District : DbEntityBase
    {
        public int Number { get; set; }

        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
