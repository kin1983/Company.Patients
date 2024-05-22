
using AutoMapper;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Commands.Update
{
  public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, bool>
  {

    private readonly IRepository<PatientEntity> _repository;
    private readonly IMapper _mapper;

    public UpdatePatientCommandHandler(IRepository<PatientEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
      var entity = _mapper.Map<PatientEntity>(request);
      entity.Id = entity.Name.Id;
      var result = await _repository.UpdateAsync(entity, cancellationToken);
      return result;
    }
  }
}
