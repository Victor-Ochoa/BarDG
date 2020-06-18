using Xunit;
using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity.Tests
{
    public class ItemTests
    {
        [Fact()]
        public void AddDescontoTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var item = new Item(produto);

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 20,
                DescontoMaximo = false,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {}
            };

            item.AddDesconto(promocao);

            Assert.Equal(30, item.ValorTotal);
        }

        [Fact()]
        public void AddDescontoValorMaxTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var item = new Item(produto);

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {}
            };

            item.AddDesconto(promocao);

            Assert.Equal(0, item.ValorTotal);
        }
    }
}