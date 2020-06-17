using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarDG.Domain.Interface
{
    public interface IRepository<T> 
        where T: Base.Entity 
    {
        Task<T> Get(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> GetAll(Expression<Func<T, bool>> where = null, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task Add(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);

        Task SaveChanges(CancellationToken cancellationToken = default);
        Task AddOrUpdate(T entity, CancellationToken cancellationToken = default);
    }
}
