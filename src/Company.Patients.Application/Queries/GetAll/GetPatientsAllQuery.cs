using Company.Patients.Application.Dto;
using MediatR;

namespace Company.Patients.Application.Queries.GetAll
{
  public class GetPatientsAllQuery : IRequest<List<PatientFullInfo>>
  {

  }
}
