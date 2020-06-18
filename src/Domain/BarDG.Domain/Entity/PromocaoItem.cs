using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class PromocaoItem: Base.Entity
    {
        public virtual Produto Item { get; set; }
        public virtual int Quantidade { get; set; }

    }
}
