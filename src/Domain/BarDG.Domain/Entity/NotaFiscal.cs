using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class NotaFiscal
    {
        public Guid Id { get; set; }

        public List<Produto> Produtos { get; set; }
        public decimal TotalDesconto { get; set; }
        public decimal TotalValor => Produtos.Sum(x => x.Valor);
        public decimal ValorFinal => TotalValor - TotalDesconto;


        public NotaFiscal(List<Produto> produtos)
        {
            Produtos = produtos;
        }
    }
}
