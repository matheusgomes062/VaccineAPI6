using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.PatientVaccines
{
  public class Edit
  {
    public class Command : IRequest<Result<Unit>>
    {
      public PatientVaccine PatientVaccine { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.PatientVaccine).SetValidator(new PatientVaccineValidator());
      }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var patientVaccine = await _context.PatientVaccines.FindAsync(request.PatientVaccine.PatientVaccineId);

        if (patientVaccine == null) return null;

        _mapper.Map(request.PatientVaccine, patientVaccine);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to update patientVaccine");

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}