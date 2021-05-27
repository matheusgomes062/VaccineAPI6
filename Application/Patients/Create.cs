using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Patients
{
  public class Create
  {
    public class Command : IRequest
    {
      public Patient Patient { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Patient).SetValidator(new PatientValidator());
      }
    }
    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Patients.Add(request.Patient);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}