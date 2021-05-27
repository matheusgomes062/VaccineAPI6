using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Patients
{
  public class Edit
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
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var patient = await _context.Patients.FindAsync(request.Patient.Id);

        _mapper.Map(request.Patient, patient);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}