

using AutoMapper;
using Company.Patients.Application.Dto;
using Company.Patients.Application.Exceptions;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Queries.GetById
{
  public class GetPatientsByIdQueryHandler:IRequestHandler<GetPatientsByIdQuery, PatientFullInfo>
  {

    private readonly IRepository<PatientEntity> _repository;
    private readonly IMapper _mapper;

    public GetPatientsByIdQueryHandler(IRepository<PatientEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<PatientFullInfo> Handle(GetPatientsByIdQuery request, CancellationToken cancellationToken)
    {
      var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

      if (item == null)
      {
        throw new EntityNotFountException(nameof(item));
      }

      var itemInfo = _mapper.Map<PatientFullInfo>(item);
      return itemInfo;
    }
  }
}
