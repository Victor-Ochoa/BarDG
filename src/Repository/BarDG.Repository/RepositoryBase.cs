using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarDG.Repository
{
    public class RepositoryBase<T> : Domain.Interface.IRepository<T>
        where T : Domain.Base.Entity
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        public RepositoryBase(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public Task<T> Get(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (asNoTracking)
                query.AsNoTracking();

            return query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> where = null, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (asNoTracking)
                query.AsNoTracking();

            if (where != null)
                query.Where(where);

            return query.ToListAsync(cancellationToken);
        }

        public async Task Remove(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken = default)
        {

            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
