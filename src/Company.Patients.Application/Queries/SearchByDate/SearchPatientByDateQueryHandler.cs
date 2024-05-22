
using AutoMapper;
using Company.Patients.Application.Dto;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MediatR;

namespace Company.Patients.Application.Queries.SearchByDate
{
  public class SearchPatientByDateQueryHandler
    : IRequestHandler<SearchPatientByDateQuery, List<PatientFullInfo>>
  {
    private readonly IRepository<PatientEntity> _repository;
    private readonly IMapper _mapper;

    public SearchPatientByDateQueryHandler(IRepository<PatientEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<List<PatientFullInfo>> Handle(SearchPatientByDateQuery request, CancellationToken cancellationToken)
    {


      var predicate = PredicateDateGenerator.Create(request);
      
      var entities = await _repository.SelectAsync(predicate, cancellationToken);

      var list = new List<PatientFullInfo>();
      foreach (var entity in entities)
      {
        var itemInfo = _mapper.Map<PatientFullInfo>(entity);
        list.Add(itemInfo);
      }

      return list;
    }
  }
}
