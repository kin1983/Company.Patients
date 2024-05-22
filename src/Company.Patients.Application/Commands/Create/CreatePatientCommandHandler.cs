using AutoMapper;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Commands.Create
{
  public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
  {

    private readonly IRepository<PatientEntity> _repository;
    private readonly IMapper _mapper;

    public CreatePatientCommandHandler(IRepository<PatientEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
      var entity = _mapper.Map<PatientEntity>(request);
      var id = Guid.NewGuid();
      entity.Id = id;
      entity.Name.Id = id;
      var entityId = await _repository.InsertAsync(entity, cancellationToken);
      return entityId.Name.Id;
    }
  }
}
