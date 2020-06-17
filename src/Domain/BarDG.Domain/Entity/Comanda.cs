using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Comanda : Base.Entity
    {
        public virtual List<Item> Itens { get; set; } = new List<Item>();
        public virtual DateTime DataCriacao { get; private set; } = DateTime.Now;

        public void Reset() => Itens = new List<Item>();

        public void AddItem(Produto produto)
        {
            if (Itens.Any(x => x.Produto.Equals(produto)))
            {
                foreach (var itemNaComanda in Itens)
                {
                    if (itemNaComanda.Produto.Equals(produto))
                    {
                        itemNaComanda.Quantidade++;
                    }
                }
            }
            else
            {
                Itens.Add(new Item(produto));
            }
        }

    }
}
