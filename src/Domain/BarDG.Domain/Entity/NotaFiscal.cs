using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class NotaFiscal : Base.Entity
    {

        public virtual List<Item> Items { get; set; }
        public virtual decimal TotalDesconto => Items.Sum(x => x.Desconto);
        public virtual decimal TotalValor => Items.Sum(x => x.Produto.Valor);
        public virtual decimal ValorFinal => TotalValor - TotalDesconto;


        public NotaFiscal(List<Item> items)
        {
            Items = items;
        }

        public NotaFiscal()
        {
            Items = new List<Item>();
        }
    }
}
