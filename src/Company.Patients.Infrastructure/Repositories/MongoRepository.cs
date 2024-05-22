using System.Linq.Expressions;
using Company.Patients.Application.Exceptions;
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;
using MongoDB.Driver;


namespace Company.Patients.Infrastructure.Repositories
{
  public class MongoDbRepository<TEntity> : MongoRepositoryBase, IRepository<TEntity>
  where TEntity : BaseEntity
  {
    private readonly string _collectionMName;


    public MongoDbRepository(string collectionMName, IPatientsDbContext dbContext)
      : base(dbContext)
    {
      _collectionMName = collectionMName;
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
      if (entity == null)
      {
        throw new EntityNullException(nameof(TEntity));
      }
      
      await GetCollection<TEntity>(_collectionMName)
             .InsertOneAsync(entity, null, cancellationToken);
      return entity;
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
      if (entity == null)
      {
        throw new EntityNullException(nameof(TEntity));
      }

      var selected = await GetCollection<TEntity>(_collectionMName)
        .Find(m => m.Id == entity.Id)
        .FirstOrDefaultAsync(cancellationToken);

      if (selected == null)
      {
        throw new EntityNotFountException(nameof(TEntity));
      }

      var result = await GetCollection<TEntity>(_collectionMName)
                              .ReplaceOneAsync(m => m.Id == selected.Id, entity, cancellationToken: cancellationToken);

      return result.ModifiedCount != 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
      
      var result = await GetCollection<TEntity>(_collectionMName)
                    .DeleteOneAsync(p => p.Id == id, cancellationToken: cancellationToken);
      return result.DeletedCount != 0;
    }

    public async Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
      var list = await GetCollection<TEntity>(_collectionMName)
        .Find(predicate)
        .ToListAsync(cancellationToken);
      return list;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
    {
      var list = await GetCollection<TEntity>(_collectionMName)
                                  .Find(_ => true)
                                  .ToListAsync(cancellationToken);
      return list;
    }

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
      var entity = await GetCollection<TEntity>(_collectionMName)
                                .Find(p => p.Id == id)
                                .FirstOrDefaultAsync(cancellationToken);

      return entity;
    }
  }
}
