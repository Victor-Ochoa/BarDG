using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class NotaFiscal : Base.Entity
    {

        public virtual List<NotaFiscalItem> Itens { get; set; } = new List<NotaFiscalItem>();
        public virtual decimal TotalDesconto => Itens.Sum(x => x.Desconto);
        public virtual decimal TotalValor => Itens.Sum(x => x.Valor * x.Quantidade);
        public virtual decimal ValorFinal => TotalValor - TotalDesconto;
        public DateTime DataCriacao { get;private set; } = DateTime.Now;


        public NotaFiscal(Comanda Comanda)
        {
            if(Comanda == null)
            {
                AddNotification("NotaFiscal()", "Comanda Nula");
                return;
            }


            Itens = GenerateNotaFiscalItemForComanda(Comanda).ToList();
        }

        public IEnumerable<NotaFiscalItem> GenerateNotaFiscalItemForComanda(Comanda comanda)
        {
            if (comanda.Invalid)
                AddNotification("GenerateNotaFiscalItemForComanda(Comanda)", "Comanda Invalida");
            if (!comanda.Itens.Any())
                AddNotification("GenerateNotaFiscalItemForComanda(Comanda)", "Comanda Vazia");

            foreach (var item in comanda.Itens)
            {
                yield return new NotaFiscalItem
                {
                    NomeProduto = item.Produto.Descricao,
                    Desconto = item.Desconto,
                    Quantidade = item.Quantidade,
                    Valor = item.Produto.Valor
                };
            }
        }

        public NotaFiscal()
        {
            Itens = new List<NotaFiscalItem>();

            AddNotification("NotaFiscal()", "Nota Fiscal Vazia");
        }
    }
}
