using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Vaccines;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class VaccinesController : BaseApiController
  {

    [HttpGet]
    public async Task<IActionResult> GetVaccines()
    {
      return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVaccine(Guid id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVaccine(Vaccine vaccine)
    {
      return HandleResult(await Mediator.Send(new Create.Command { Vaccine = vaccine }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditVaccine(Guid id, Vaccine vaccine)
    {
      vaccine.Id = id;
      return HandleResult(await Mediator.Send(new Edit.Command { Vaccine = vaccine }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccine(Guid id)
    {
      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
  }
}