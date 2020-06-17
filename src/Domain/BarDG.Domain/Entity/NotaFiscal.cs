using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class NotaFiscal : Base.Entity
    {

        public virtual List<Item> Itens { get; set; }
        public virtual decimal TotalDesconto => Itens.Sum(x => x.Desconto);
        public virtual decimal TotalValor => Itens.Sum(x => x.Produto.Valor);
        public virtual decimal ValorFinal => TotalValor - TotalDesconto;


        public NotaFiscal(List<Item> itens)
        {
            Itens = itens;
        }

        public NotaFiscal()
        {
            Itens = new List<Item>();
        }
    }
}
