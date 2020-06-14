using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarDG.Domain.Interface
{
    public interface IRepository<T> 
        where T: Base.Entity 
    {
        Task<T> Get(Guid id, bool asNoTracking = true);
    }
}
