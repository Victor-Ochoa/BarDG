using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarDG.Repository.ModelBinding.InitiateValue
{
    public class Promocao
    {
        public static Domain.Entity.Promocao PromoCerveja = new Domain.Entity.Promocao()
        {
            Id = 1,
            Desconto = 2,
            DescontoMaximo = false,
            ItemDesconto = Produto.Cerveja,
            RepetirPromocao = true,
            ItensAtivadores = new Domain.Entity.PromocaoItem[]
            {
                new Domain.Entity.PromocaoItem()
                {
                    Id = 1,
                    Item = Produto.Cerveja,
                    Quantidade = 1
                },
                new Domain.Entity.PromocaoItem()
                {
                    Id = 2,
                    Item = Produto.Suco,
                    Quantidade = 1
                }
            }
        };

        public static Domain.Entity.Promocao PromoAgua = new Domain.Entity.Promocao()
        {
            Id = 2,
            Desconto = 0,
            DescontoMaximo = true,
            ItemDesconto = Produto.Água,
            RepetirPromocao = false,
            ItensAtivadores = new Domain.Entity.PromocaoItem[]
            {
                new Domain.Entity.PromocaoItem()
                {
                    Id = 3,
                    Item = Produto.Conhaque,
                    Quantidade = 3
                },
                new Domain.Entity.PromocaoItem()
                {
                    Id = 4,
                    Item = Produto.Cerveja,
                    Quantidade = 2
                }
            }
        };
    }
}
