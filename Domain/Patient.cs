using System;

namespace Domain
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public DateTime Birthdate { get; set; }

        public bool Comorbidity { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string City { get; set; }
    }
}
