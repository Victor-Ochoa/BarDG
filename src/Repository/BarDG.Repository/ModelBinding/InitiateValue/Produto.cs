using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Repository.ModelBinding.InitiateValue
{
    public class Produto
    {
        public static Domain.Entity.Produto Cerveja = new Domain.Entity.Produto()
        {
            Id = 1,
            Descricao = "Cerveja",
            Valor = 5
            
        };
        public static Domain.Entity.Produto Conhaque = new Domain.Entity.Produto()
        {
            Id = 2,
            Descricao = "Conhaque",
            Valor = 20
        };
        public static Domain.Entity.Produto Suco = new Domain.Entity.Produto()
        {
            Id = 3,
            Descricao = "Suco",
            Valor = 50,
            CompraMaxima = 3
        };
        public static Domain.Entity.Produto Água = new Domain.Entity.Produto()
        {
            Id = 4,
            Descricao = "Água",
            Valor = 70
        };
    }
}
