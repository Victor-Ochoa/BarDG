using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding.InitiateValue
{
    public class Produto
    {
        public static Domain.Entity.Produto Cerveja = new Domain.Entity.Produto()
        {
            Descricao = "Cerveja",
            Valor = 5
        };
        public static Domain.Entity.Produto Conhaque = new Domain.Entity.Produto()
        {
            Descricao = "Conhaque",
            Valor = 20
        };
        public static Domain.Entity.Produto Suco = new Domain.Entity.Produto()
        {
            Descricao = "Suco",
            Valor = 50,
            CompraMaxima = 3
        };
        public static Domain.Entity.Produto Água = new Domain.Entity.Produto()
        {
            Descricao = "Água",
            Valor = 70
        };
    }
}
