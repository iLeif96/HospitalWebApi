using Hospital.Domain.Entities;
using Hospital.Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class DoctorsRepositoryEF : GenericRepositoryEF<Doctor>
    {
        public DoctorsRepositoryEF(HospitalContext hospitalContext) : base(hospitalContext)
        {

        }

        protected override IQueryable<Doctor> IncludeMembers(IQueryable<Doctor>? query = null)
        {
            return base.IncludeMembers(query)
                .Include(doctor => doctor.Office)
                .Include(doctor => doctor.Specialization)
                .Include(doctor => doctor.District);
        }
    }
}
