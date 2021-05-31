using Domain;
using FluentValidation;

namespace Application.PatientVaccines
{
  public class PatientVaccineValidator : AbstractValidator<PatientVaccine>
  {
    public PatientVaccineValidator()
    {
      RuleFor(x => x.ApplicationDate).NotEmpty();
      RuleFor(x => x.Patient.Name).NotEmpty();
      RuleFor(x => x.Vaccine.Name).NotEmpty();
      RuleFor(x => x.DoseApplied).NotEmpty();
      RuleFor(x => x.CompleteVaccination).NotEmpty();
    }
  }
}