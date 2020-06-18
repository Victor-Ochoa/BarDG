using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Promocao : Base.Entity
    {
        public virtual IEnumerable<PromocaoItem> ItensAtivadores { get; set; }
        public virtual Produto ItemDesconto { get; set; }
        public virtual decimal Desconto { get; set; }
        public virtual bool DescontoMaximo { get; set; }
        public virtual bool RepetirPromocao { get; set; }
    }
}
