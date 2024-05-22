using Company.Patients.Application.Interfaces;
using MongoDB.Driver;

namespace Company.Patients.Infrastructure.Repositories
{
    public class MongoRepositoryBase
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoRepositoryBase(IPatientsDbContext dbContext)
        {
            _mongoDatabase = dbContext.GetSource<IMongoDatabase>();
        }

        protected IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}
