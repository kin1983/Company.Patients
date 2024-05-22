
using Company.Patients.Application.Dto;
using MediatR;

namespace Company.Patients.Application.Queries.SearchByDate
{
  public class SearchPatientByDateQuery : IRequest<List<PatientFullInfo>>
  {
    public string Date { get; set; }

  }
}
