using Hospital.Domain.Common;

namespace Hospital.Domain.Entities
{
    public class Doctor : DbEntityBase
    {
        public string FullName { get; set; }
        public Office Office { get; set; }
        public Specialization Specialization { get; set; }
        public District? District { get; set; }

    }
}
