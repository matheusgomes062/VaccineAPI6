using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.Patients.Any()) return;
            if(context.Vaccines.Any()) return;

            var patients = new List<Patient>
            {
                new Patient
                {
                    Name = "Matheus Gomes",
                    Email = "matheusgomes062@gmail.com",
                    Cpf = "103.439.869-57",
                    Birthdate = DateTime.Now,
                    Comorbidity = false,
                    Address = "Rua Pedro Tursi, 116",
                    District = "Jardim Satélite",
                    State = "São Paulo",
                    City = "São José dos Campos"
                },
                new Patient
                {
                    Name = "Daniel Salis",
                    Email = "barretos@gmail.com",
                    Cpf = "935.344.550-70",
                    Birthdate = DateTime.Now,
                    Comorbidity = false,
                    Address = "Rua Counter Strike, 420",
                    District = "Jardim Steam",
                    State = "São Paulo",
                    City = "Barretos"
                },
                new Patient
                {
                    Name = "Milena Matos",
                    Email = "leninha@gmail.com",
                    Cpf = "114.059.180-04",
                    Birthdate = DateTime.Now,
                    Comorbidity = false,
                    Address = "Rua Twitter, 123",
                    District = "Jardim Social",
                    State = "São Paulo",
                    City = "São José dos Campos"
                },
            };


            var vaccines = new List<Vaccine>
            {
                new Vaccine
                {
                    Name = "Pfizer-BioNTech",
                    Manufacturer = "Pfizer, Inc., and BioNTech",
                    Batch = 1,
                    DueDate = DateTime.Now.AddMonths(3),
                    NumberOfDoses = 2,
                    IntervalBetweenDoses = 21,
                },
                new Vaccine
                {
                    Name = "Moderna",
                    Manufacturer = "ModernaTX, Inc.",
                    Batch = 1,
                    DueDate = DateTime.Now.AddMonths(3),
                    NumberOfDoses = 2,
                    IntervalBetweenDoses = 28,
                },
                new Vaccine
                {
                    Name = "Johnson & Johnson’s Janssen",
                    Manufacturer = "Janssen Pharmaceuticals Companies of Johnson & Johnson",
                    Batch = 1,
                    DueDate = DateTime.Now.AddMonths(3),
                    NumberOfDoses = 1,
                    IntervalBetweenDoses = 0,
                },
            };

            await context.Patients.AddRangeAsync(patients);
            await context.Vaccines.AddRangeAsync(vaccines);
            await context.SaveChangesAsync();
        }
    }
}