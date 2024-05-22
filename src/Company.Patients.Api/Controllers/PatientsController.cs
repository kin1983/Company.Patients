using AutoMapper;
using Company.Patients.Application.Commands.Create;
using Company.Patients.Application.Commands.Delete;
using Company.Patients.Application.Commands.Update;
using Company.Patients.Application.Dto;
using Company.Patients.Application.Queries.GetAll;
using Company.Patients.Application.Queries.GetById;
using Company.Patients.Application.Queries.SearchByDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Company.Patients.Api.Controllers
{

  [Route("api/[controller]/[action]")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PatientsController(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    // GET: api/<PatientsController>
    [HttpGet]
    public async Task<ActionResult<List<PatientFullInfo>>> Get()
    {
      var query = new GetPatientsAllQuery();
      var result = await _mediator.Send(query);
      return Ok(result);

    }


    // GET: api/<PatientsController>
    [HttpGet("{id}")]
    public async Task<ActionResult<List<PatientFullInfo>>> Get(Guid id)
    {
      var query = new GetPatientsByIdQuery{Id = id};
      var result = await _mediator.Send(query);
      return Ok(result);

    }


    // GET: api/<PatientsController>
    [HttpGet]
    public async Task<ActionResult<List<PatientFullInfo>>> SearchByDate([FromQuery] string date)
    {
      var query = new SearchPatientByDateQuery { Date = date };
      var result = await _mediator.Send(query);
      return Ok(result);

    }

    // POST api/<PatientsController>
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] PatientInfo patientInfo)
    {
      var command = _mapper.Map<CreatePatientCommand>(patientInfo);
      var result = await _mediator.Send(command);
      return Ok(result);
    }

    // PUT api/<PatientsController>
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PatientFullInfo patientInfo)
    {
      var command = _mapper.Map<UpdatePatientCommand>(patientInfo);
      await _mediator.Send(command);
      return NoContent();
    }

    // DELETE api/<PatientsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      var command = new DeletePatientCommand() { Id = id };
      await _mediator.Send(command);
      return NoContent();
    }
  }
}
