using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarDG.Domain.Interface
{
    public interface IRepository<T> 
        where T: Base.Entity 
    {
        Task<T> Get(Guid id, bool asNoTracking = false);
        Task<List<T>> GetAll(Expression<Func<T, bool>> where = null, bool asNoTracking = false);
    }
}
