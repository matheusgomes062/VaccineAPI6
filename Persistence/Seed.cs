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

            await context.Patients.AddRangeAsync(patients);
            await context.SaveChangesAsync();
        }
    }
}