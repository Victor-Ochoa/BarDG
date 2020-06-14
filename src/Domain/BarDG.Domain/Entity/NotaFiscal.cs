using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class NotaFiscal : Base.Entity
    {

        public virtual List<Produto> Produtos { get; set; }
        public virtual decimal TotalDesconto { get; set; }
        public virtual decimal TotalValor => Produtos.Sum(x => x.Valor);
        public virtual decimal ValorFinal => TotalValor - TotalDesconto;


        public NotaFiscal(List<Produto> produtos)
        {
            Produtos = produtos;
        }

        public NotaFiscal()
        {
            Produtos = new List<Produto>();
        }
    }
}
