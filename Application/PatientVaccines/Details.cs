
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.PatientVaccines
{
  public class Details
  {
    public class Query : IRequest<Result<PatientVaccine>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<PatientVaccine>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<PatientVaccine>> Handle(Query request, CancellationToken cancellationToken)
      {
        var patientVaccine = await _context.PatientVaccines.FindAsync(request.Id);
        return Result<PatientVaccine>.Success(patientVaccine);
      }
    }
  }
}