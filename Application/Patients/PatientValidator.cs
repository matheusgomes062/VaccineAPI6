using Domain;
using FluentValidation;

namespace Application.Patients
{
  public class PatientValidator : AbstractValidator<Patient>
  {
    public PatientValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.Email).NotEmpty().EmailAddress();
      RuleFor(x => x.Cpf).NotEmpty().IsValidCPF();
      RuleFor(x => x.Birthdate).NotEmpty();
      RuleFor(x => x.Comorbidity).NotEmpty().NotNull();
      RuleFor(x => x.Address).NotEmpty();
      RuleFor(x => x.District).NotEmpty();
      RuleFor(x => x.State).NotEmpty();
      RuleFor(x => x.City).NotEmpty();
    }
  }
}