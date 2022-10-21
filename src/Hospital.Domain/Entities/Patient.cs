using Hospital.Domain.Common;

namespace Hospital.Domain.Entities
{
    public class Patient : DbEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime Birth { get; set; }
        public District District { get; set; }
    }
}
