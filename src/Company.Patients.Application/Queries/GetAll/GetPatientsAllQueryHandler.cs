using AutoMapper;
using Company.Patients.Application.Dto;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Queries.GetAll
{
  public class GetPatientsAllQueryHandler : IRequestHandler<GetPatientsAllQuery, List<PatientFullInfo>>
  {
    private readonly IRepository<PatientEntity> _repository;
    private readonly IMapper _mapper;

    public GetPatientsAllQueryHandler(IRepository<PatientEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<List<PatientFullInfo>> Handle(GetPatientsAllQuery request, CancellationToken cancellationToken)
    {
      var entities = await _repository.GetAsync(cancellationToken);
      var list = new List<PatientFullInfo>();
      foreach (var item in entities)
      {
        var itemVm = _mapper.Map<PatientFullInfo>(item);
        list.Add(itemVm);
      }
      return list;
    }
  }
}
