using Xunit;
using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Entity.Tests
{
    public class PromocaoTests
    {
        [Fact()]
        public void PromocaoValidaTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = false
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);

            Assert.True(promValid, "Promoção valida");
        }

        [Fact()]
        public void PromocaoValidaExedTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = false
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);

            Assert.True(promValid, "Promoção valida com mais itens que o necessário");
        }
        [Fact()]
        public void PromocaoInvalidaTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = false
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);

            Assert.False(promValid, "Promoção invalida");
        }

        [Fact()]
        public void Repetir1VezesTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = true
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);
            var repetir = promocao.RepetirXVezes(comanda);

            Assert.True(promocao.Valid, "Promoção valida");
            Assert.True(promValid, "Promoção pode ser aplicada");
            Assert.Equal(1, repetir);
        }

        [Fact()]
        public void Repetir2VezesTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = true
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);
            var repetir = promocao.RepetirXVezes(comanda);

            Assert.True(promocao.Valid, "Promoção valida");
            Assert.True(promValid, "Promoção pode ser aplicada");
            Assert.Equal(2, repetir);
        }

        [Fact()]
        public void Repetir2Vezes2ProdTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };
            var produto2 = new Produto()
            {
                Descricao = "Prod Test 2",
                Id = 2,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    },
                    new PromocaoItem {
                        Id = 2,
                        Item = produto2,
                        Quantidade = 1
                    }
                },
                RepetirPromocao = true
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);

            var promValid = promocao.PromocaoValida(comanda);
            var repetir = promocao.RepetirXVezes(comanda);

            Assert.True(promocao.Valid, "Promoção valida");
            Assert.True(promValid, "Promoção pode ser aplicada");
            Assert.Equal(2, repetir);
        }

        [Fact()]
        public void Repetir0VezesTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = true
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);
            var repetir = promocao.RepetirXVezes(comanda);

            Assert.False(promValid, "Promoção não pode ser aplicada");
            Assert.Equal(0, repetir);
        }
        [Fact()]
        public void RepetirNaoVezesTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 2
                    }
                },
                RepetirPromocao = false
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            var promValid = promocao.PromocaoValida(comanda);
            var repetir = promocao.RepetirXVezes(comanda);

            Assert.True(promocao.Invalid, "Promoção valida");
            Assert.True(promValid, "Promoção pode ser aplicada");
            Assert.Equal(0, repetir);
        }
    }
}