using Company.Patients.Domain.Types;
using MediatR;

namespace Company.Patients.Application.Commands.Create
{
  public class CreatePatientCommand : IRequest<Guid>
  {
    public PatientGenderType GenderType { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public CreatePatientDetailCommand Name { get; set; }

  }
}
