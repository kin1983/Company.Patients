

using MediatR;

namespace Company.Patients.Application.Commands.Delete
{
  public class DeletePatientCommand : IRequest<bool>
  {
    public Guid Id { get; set; }
  }
}
