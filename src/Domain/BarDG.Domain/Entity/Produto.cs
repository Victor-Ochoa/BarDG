using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Produto : Base.Entity
    {
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
    }
}
