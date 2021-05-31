using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.PatientVaccines
{
  public class List
  {
    public class Query : IRequest<Result<List<PatientVaccine>>> { }

    public class Handler : IRequestHandler<Query, Result<List<PatientVaccine>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }

      public async Task<Result<List<PatientVaccine>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return Result<List<PatientVaccine>>.Success(await _context.PatientVaccines.ToListAsync());
      }
    }
  }
}