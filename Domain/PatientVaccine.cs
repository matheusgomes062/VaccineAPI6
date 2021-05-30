using System;

namespace Domain
{
  public class PatientVaccine
  {
    public Guid PatientVaccineId { get; set; }
    
    public Guid PatientId { get; set; }

    public Patient Patient { get; set; }

    public Guid VaccineId { get; set; }

    public Vaccine Vaccine { get; set; }

    public int DoseApplied { get; set; }

    public bool CompleteVaccination { get; set; }
  }
}