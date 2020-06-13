using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Interface
{
    public interface IRepository<T> where T: Base.Entity
    {
        T Get(Guid id);
    }
}
