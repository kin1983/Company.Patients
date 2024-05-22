using Company.Patients.Domain.Types;
using MediatR;

namespace Company.Patients.Application.Commands.Update
{
  public class UpdatePatientCommand : IRequest<bool>
  {
    public PatientGenderType GenderType { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public UpdatePatientDetailCommand Name { get; set; }
  }
}
