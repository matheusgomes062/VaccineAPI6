using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.PatientVaccines;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class PatientVaccinesController : BaseApiController
  {

    [HttpGet]
    public async Task<IActionResult> GetPatientVaccines()
    {
      return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientVaccine(Guid id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatientVaccine(PatientVaccine patientVaccine)
    {
      return HandleResult(await Mediator.Send(new Create.Command { PatientVaccine = patientVaccine }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditPatientVaccine(Guid id, PatientVaccine patientVaccine)
    {
      patientVaccine.PatientVaccineId = id;
      return HandleResult(await Mediator.Send(new Edit.Command { PatientVaccine = patientVaccine }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatientVaccine(Guid id)
    {
      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
  }
}