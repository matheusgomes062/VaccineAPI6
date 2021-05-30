using Domain;
using FluentValidation;

namespace Application.Vaccines
{
  public class VaccineValidator : AbstractValidator<Vaccine>
  {
    public VaccineValidator()
    {
      RuleFor(x => x.Name).NotEmpty();
      RuleFor(x => x.Manufacturer).NotEmpty();
      RuleFor(x => x.Batch).NotEmpty();
      RuleFor(x => x.DueDate).NotEmpty().NotNull();
      RuleFor(x => x.NumberOfDoses).NotEmpty();
      RuleFor(x => x.IntervalBetweenDoses).NotEmpty();
    }
  }
}