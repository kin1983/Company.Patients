using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Commands.Delete
{
  public class DeletePatientCommandHandler:IRequestHandler<DeletePatientCommand, bool>
  {
    private readonly IRepository<PatientEntity> _repository;

    public DeletePatientCommandHandler(IRepository<PatientEntity> repository)
    {
      _repository = repository;
    }
    public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
      var result = await _repository.DeleteAsync(request.Id, cancellationToken);
      return result;
    }
  }
}
