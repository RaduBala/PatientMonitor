using Application.Patients.Commands.CreatePatient;
using Application.Patients.Commands.UpdatePatient;
using Application.Patients.Queries.GetAllPatients;
using Application.Patients.Queries.GetDynamicData;
using Application.Patients.Queries.GetPatient;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator mediator;

        public PatientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var query  = new GetAllPatientsQuery();
            var result = await mediator.Send(query);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<GetPatientDto> GetAsync(int id)
        {
            var query = new GetPatientQuery() { Id = id };
            var result = await mediator.Send(query);

            return result;
        }

        [HttpGet("dynamic/{id}")]
        public async Task<PatientDynamicData> GetDynamicDataAsync(int id)
        {
            var query  = new GetDynamicDataQuery() { Id = id };
            var result = await mediator.Send(query);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreatePatientCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(); 
        }
         
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdatePatientCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
