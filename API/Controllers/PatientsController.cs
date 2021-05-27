using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Patients;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class PatientsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatients()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }
    }
}