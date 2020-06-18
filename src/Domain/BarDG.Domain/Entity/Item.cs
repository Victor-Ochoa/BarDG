using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Item : Base.Entity
    {
        public virtual Produto Produto { get; set; }

        public virtual decimal Desconto { get; set; } = 0M;

        public virtual int Quantidade { get; set; } = 1;

        public decimal ValorTotal => (Produto.Valor * Quantidade )- Desconto ;

        public Item() { }

        public Item(Produto produto)
        {
            Produto = produto;
        }

        public void AddDesconto(Promocao promocao)
        {
            if (Produto == promocao.ItemDesconto)
                Desconto += promocao.ValorDesconto;
        }
    }
}
