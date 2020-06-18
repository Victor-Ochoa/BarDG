using Xunit;
using BarDG.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BarDG.Domain.Entity.Tests
{
    public class ComandaTests
    {
        [Fact()]
        public void AddItemTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);

            Assert.True(comanda.Valid, "Comanda segue valida");
            Assert.True(comanda.Itens.Count == 1, "Adicionado o item na lista");
            Assert.True(comanda.Itens.First().Quantidade == 1, "Adicionado a quantidade");

        }

        [Fact()]
        public void AddItemAumQuantTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);

            Assert.True(comanda.Valid, "Comanda segue valida");
            Assert.True(comanda.Itens.Count == 1, "Adicionado o item na lista");
            Assert.True(comanda.Itens.First().Quantidade == 2, "Adicionado a quantidade");

        }

        [Fact()]
        public void Add2ItemTest()
        {
            var produto = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 1,
                Valor = 50
            };

            var produto2 = new Produto()
            {
                CompraMaxima = 3,
                Descricao = "Prod Test",
                Id = 2,
                Valor = 50
            };
            var comanda = new Comanda()
            {
                Id = 1
            };
            comanda.AddItem(produto);
            comanda.AddItem(produto);
            comanda.AddItem(produto2);

            Assert.True(comanda.Valid, "Comanda segue valida");
            Assert.True(comanda.Itens.Count == 2, "Adicionado o item na lista");
            Assert.True(comanda.Itens.Single(x => x.Produto.Id == 1).Quantidade == 2, "Adicionado a quantidade ao prod 1");
            Assert.True(comanda.Itens.Single(x => x.Produto.Id == 2).Quantidade == 1, "Adicionado a quantidade ao prod 2");

        }

        [Fact()]
        public void AplicarPromoCerv1vezTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 5
            };

            var produto2 = new Produto()
            {
                Descricao = "Prod Test2",
                Id = 2,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 2,
                DescontoMaximo = false,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 1
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
            comanda.AddItem(produto2);
            comanda.AplicarPromo(promocao);

            Assert.Equal(3, comanda.Itens.Single(x => x.Produto.Id == 1).ValorTotal);
        }

        [Fact()]
        public void AplicarPromoCerv2vezTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 5
            };

            var produto2 = new Produto()
            {
                Descricao = "Prod Test2",
                Id = 2,
                Valor = 50
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 2,
                DescontoMaximo = false,
                ItemDesconto = produto,
                ItensAtivadores = new PromocaoItem[]
                {
                    new PromocaoItem {
                        Id = 1,
                        Item = produto,
                        Quantidade = 1
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
            comanda.AddItem(produto2);
            comanda.AddItem(produto);
            comanda.AddItem(produto2);
            comanda.AplicarPromo(promocao);

            Assert.Equal(6, comanda.Itens.Single(x => x.Produto.Id == 1).ValorTotal);
        }

        [Fact()]
        public void AplicarPromoAguaSemAguaTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 5
            };

            var produto2 = new Produto()
            {
                Descricao = "Prod Test2",
                Id = 2,
                Valor = 20
            };

            var produto3 = new Produto()
            {
                Descricao = "Prod Test3",
                Id = 3,
                Valor = 70
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto3,
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
                        Quantidade = 3
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
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);

            comanda.AplicarPromo(promocao);

            Assert.Equal(70, comanda.Itens.Sum(x => x.ValorTotal));
        }

        [Fact()]
        public void AplicarPromoAguaComAguaTest()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 5
            };

            var produto2 = new Produto()
            {
                Descricao = "Prod Test2",
                Id = 2,
                Valor = 20
            };

            var produto3 = new Produto()
            {
                Descricao = "Prod Test3",
                Id = 3,
                Valor = 70
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto3,
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
                        Quantidade = 3
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
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);
            comanda.AddItem(produto3);

            comanda.AplicarPromo(promocao);

            Assert.Equal(70, comanda.Itens.Sum(x => x.ValorTotal));
        }

        [Fact()]
        public void AplicarPromoAguaComAgua2Test()
        {
            var produto = new Produto()
            {
                Descricao = "Prod Test",
                Id = 1,
                Valor = 5
            };

            var produto2 = new Produto()
            {
                Descricao = "Prod Test2",
                Id = 2,
                Valor = 20
            };

            var produto3 = new Produto()
            {
                Descricao = "Prod Test3",
                Id = 3,
                Valor = 70
            };

            var promocao = new Promocao
            {
                Id = 1,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = produto3,
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
                        Quantidade = 3
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
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);
            comanda.AddItem(produto2);
            comanda.AddItem(produto3);
            comanda.AddItem(produto3);

            comanda.AplicarPromo(promocao);

            Assert.Equal(140, comanda.Itens.Sum(x => x.ValorTotal));
        }
    }
}