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

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public Task<T> Get(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
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

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task AddOrUpdate(T entity, CancellationToken cancellationToken = default)
        {
            var exist = (await Get(entity.Id, cancellationToken: cancellationToken))!= null;

            if (exist)
                await Update(entity);
            else
                await Add(entity);
        }
    }
}
