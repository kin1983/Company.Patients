
using System.Linq.Expressions;
using Company.Patients.Domain.Entities;

namespace Company.Patients.Application.Interfaces
{

  public interface IRepository<TEntity> where TEntity : BaseEntity
  {
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

  }
}
