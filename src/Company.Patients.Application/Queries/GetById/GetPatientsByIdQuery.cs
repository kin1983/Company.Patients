using Company.Patients.Application.Dto;
using MediatR;

namespace Company.Patients.Application.Queries.GetById
{
  public class GetPatientsByIdQuery : IRequest<PatientFullInfo>
  {
    public Guid Id { get; set; }
  }
}
