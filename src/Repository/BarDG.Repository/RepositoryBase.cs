using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
