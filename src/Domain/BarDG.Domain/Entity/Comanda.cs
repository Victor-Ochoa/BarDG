using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BarDG.Domain.Entity
{
    public class Comanda : Base.Entity
    {
        private List<Produto> _produtos;

        public ReadOnlyCollection<Produto> Produtos
        {
            get { return _produtos.AsReadOnly(); }
        }

        public void AddProduto(Produto produto) => _produtos.Add(produto);
    }
}
