using Hospital.Domain.Entities;
using Hospital.Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class PatientsRepositoryEF : GenericRepositoryEF<Patient>
    {
        public PatientsRepositoryEF(HospitalContext hospitalContext) : base(hospitalContext)
        {

        }

        protected override IQueryable<Patient> IncludeMembers(IQueryable<Patient>? query = null)
        {
            return base.IncludeMembers(query)
                .Include(patient => patient.District);
        }
    }
}
