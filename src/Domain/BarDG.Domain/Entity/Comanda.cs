using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Comanda : Base.Entity
    {
        public virtual List<Produto> Produtos { get; set; } = new List<Produto>();

    }
}
