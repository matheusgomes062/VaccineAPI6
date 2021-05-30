using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Vaccines
{
  public class List
  {
    public class Query : IRequest<Result<List<Vaccine>>> { }

    public class Handler : IRequestHandler<Query, Result<List<Vaccine>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;

      }

      public async Task<Result<List<Vaccine>>> Handle(Query request, CancellationToken cancellationToken)
      {
        return Result<List<Vaccine>>.Success(await _context.Vaccines.ToListAsync());
      }
    }
  }
}