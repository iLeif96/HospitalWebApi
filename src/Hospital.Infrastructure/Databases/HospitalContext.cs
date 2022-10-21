
using Hospital.Domain.Entities;
using Hospital.Infrastructure.Helpers;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Databases
{
    public class HospitalContext : DbContext
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

            //CreateDatabase(false);
        }

        public void Initialize(bool isNeedClearDatabase)
        {
            CreateDatabase(isNeedClearDatabase);

            if (!Districts.Any() || !Offices.Any() || !Specializations.Any() || !Doctors.Any() || !Patients.Any())
            {
                DataBaseHelper.FillDatabase(this);
            }
        }

        private bool CreateDatabase(bool isNeedDeleteBeforeCreate)
        {
            if (isNeedDeleteBeforeCreate)
            {
                Database.EnsureDeleted();
            }

            return Database.EnsureCreated();
        }
    }
}
