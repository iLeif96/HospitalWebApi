using Hospital.Domain.Common;

namespace Hospital.Domain.Entities
{
    public class Specialization : DbEntityBase
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
