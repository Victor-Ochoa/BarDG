using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
