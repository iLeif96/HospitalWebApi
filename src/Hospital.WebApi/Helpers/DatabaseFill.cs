using Hospital.Domain.Entities;
using Hospital.Infrastructure.Databases;

namespace Hospital.WebApi.Helpers
{
    public static class DataBaseHelper
    {
        public static void FillDatabase(HospitalContext db)
        {
            var specs = CreateSpecialisations();
            var offices = CreateOffices();
            var districts = CreateDistricts();

            db.Specializations.AddRange(specs);
            db.Offices.AddRange(offices);
            db.Districts.AddRange(districts);

            db.SaveChanges();

            var doctors = CreateDoctors(offices, districts, specs);
            var patients = CreatePatients(districts);

            db.Doctors.AddRange(doctors);
            db.Patients.AddRange(patients);

            db.SaveChanges();
        }

        private static List<Specialization> CreateSpecialisations()
        {
            return new List<Specialization>()
            {
                new Specialization() { Name = "Вирусолог" },
                new Specialization() { Name = "Терапевт" },
                new Specialization() { Name = "Ортодонт" },
                new Specialization() { Name = "Ортопед" },
                new Specialization() { Name = "Трихолог" },
                new Specialization() { Name = "Ревматолог" },
            };
        }

        private static List<Office> CreateOffices()
        {
            return new List<Office>()
            {
                new Office() { Number = 101 },
                new Office() { Number = 102 },
                new Office() { Number = 103 },
                new Office() { Number = 104 },
                new Office() { Number = 105 },
                new Office() { Number = 106 },
                new Office() { Number = 107 },
                new Office() { Number = 108 },
                new Office() { Number = 109 },
            };
        }
        private static List<District> CreateDistricts()
        {
            return new List<District>()
            {
                new District() { Number = 1 },
                new District() { Number = 2 },
                new District() { Number = 3 },
                new District() { Number = 4 },
                new District() { Number = 5 },
            };
        }

        private static List<Doctor> CreateDoctors(List<Office> offices, List<District> districts, List<Specialization> specializations)
        {
            return new List<Doctor>()
            {
                new Doctor() { FullName = "Понеяда Линда Валерьевна",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },
                new Doctor() { FullName = "Сидова Милана Ильинична",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },
                new Doctor() { FullName = "Видов Геннадий Павлович",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },
                new Doctor() { FullName = "Ивова Алена Артемовна",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },
                new Doctor() { FullName = "Привалова Зоя Вячеславовна",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },
                new Doctor() { FullName = "Шевцов Игорь Дмитриевич",
                    Office = GetRand(offices), Specialization = GetRand(specializations), District = GetRand(districts, true) },

            };
        }

        private static List<Patient> CreatePatients(List<District> districts)
        {
            return new List<Patient>()
            {
                new Patient() {FirstName = "Алина", LastName = "Пивоварова", Patronymic = "Олеговна",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},
                new Patient() {FirstName = "Олег", LastName = "Пивоваров", Patronymic = "Олегович",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},
                new Patient() {FirstName = "Ярослав", LastName = "Глобов", Patronymic = "Винеаминович",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},
                new Patient() {FirstName = "Галина", LastName = "Водянова", Patronymic = "Аркадьевна",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},
                new Patient() {FirstName = "Светлана", LastName = "Слободкина", Patronymic = "Викторовна",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},
                new Patient() {FirstName = "Петр", LastName = "Говорун", Patronymic = "Глебович",
                    Birth = GetRandomDate(), District = GetRand(districts), Adress = "Восточная, 5"},


            };
        }

        private static T GetRand<T>(List<T> values, bool isNullPossible = false) where T : class
        {
            Random random = new Random();
            int count = values.Count();

            if (isNullPossible && random.Next(0, 3) == 0)
            {
                return null;
            }

            int index = random.Next(0, count);
            return values[index];
        }

        private static DateTime GetRandomDate()
        {
            Random random = new Random();
            return new DateTime(random.Next(1950, 2010), random.Next(1, 13), random.Next(1, 8));
        }
    }
}
