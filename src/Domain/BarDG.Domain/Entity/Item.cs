using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Item: Base.Entity
    {
        public virtual Produto Produto { get; set; }

        public virtual decimal Desconto { get; set; }

        public Item()
        {

        }

        public Item(Produto produto)
        {
            Produto = produto;
        }
    }
}
