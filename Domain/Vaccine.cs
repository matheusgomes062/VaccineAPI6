using System;
using System.Collections.Generic;

namespace Domain
{
  public class Vaccine
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Manufacturer { get; set; }

    public int Batch { get; set; }

    public DateTime DueDate { get; set; }

    public int NumberOfDoses { get; set; }

    public int IntervalBetweenDoses { get; set; }

    public ICollection<PatientVaccine> PatientVaccines { get; set; }
  }
}
