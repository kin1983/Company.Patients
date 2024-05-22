using Company.Patients.Application.Interfaces;
using MongoDB.Driver;

namespace Company.Patients.Infrastructure.DbContext
{
  public class PatientsDbContext : IPatientsDbContext
  {

   private readonly IMongoDatabase _mongoDatabase;

    public PatientsDbContext(IMongoDatabase mongoDatabase)
    {
      _mongoDatabase = mongoDatabase;
    }
    
    public TMongoDatabase GetSource<TMongoDatabase>()
    {
      return (TMongoDatabase)_mongoDatabase;
    }
  }
}
