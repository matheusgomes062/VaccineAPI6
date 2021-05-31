using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.PatientVaccines
{
  public class Delete
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var patientVaccine = await _context.PatientVaccines.FindAsync(request.Id);

        if (patientVaccine == null) return null;

        _context.Remove(patientVaccine);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to delete the patientVaccine");

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}