using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarDG.Repository
{
    public class RepositoryBase<T> : Domain.Interface.IRepository<T>
        where T : Domain.Base.Entity
    {
        private readonly DbSet<T> DbSet;
        public RepositoryBase(ApiDbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
        }

        public Task<T> Get(Guid id, bool asNoTracking = true)
        {
            var query = DbSet.AsQueryable();

            if (asNoTracking)
                query.AsNoTracking();

            return query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> where = null, bool asNoTracking = false)
        {
            var query = DbSet.AsQueryable();

            if (asNoTracking)
                query.AsNoTracking();

            if (where != null)
                query.Where(where);

            return query.ToListAsync();
        }
    }
}
