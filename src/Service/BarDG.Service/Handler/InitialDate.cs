using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarDG.Service.Handler
{
    public class InitialDate : IRequestHandler<Domain.Command.InitialDate>
    {
        private readonly IRepository<Produto> _repositoryProduto;
        private readonly IRepository<Promocao> _repositoryPromocao;
        private readonly IRepository<PromocaoItem> _repositoryPromocaoItem;

        public InitialDate(IRepository<Produto> repositoryProduto, IRepository<Promocao> repositoryPromocao, IRepository<PromocaoItem> repositoryPromocaoItem)
        {
            this._repositoryProduto = repositoryProduto;
            this._repositoryPromocao = repositoryPromocao;
            this._repositoryPromocaoItem = repositoryPromocaoItem;
        }

        public async Task<Unit> Handle(Domain.Command.InitialDate request, CancellationToken cancellationToken)
        {
            var cerveja = new Domain.Entity.Produto()
            {
                Descricao = "Cerveja",
                Valor = 5

            };
            var conhaque = new Domain.Entity.Produto()
            {
                Descricao = "Conhaque",
                Valor = 20
            };
            var suco = new Domain.Entity.Produto()
            {
                Descricao = "Suco",
                Valor = 50,
                CompraMaxima = 3
            };
            var agua = new Domain.Entity.Produto()
            {
                Descricao = "Água",
                Valor = 70
            };


            await _repositoryProduto.Add(cerveja, cancellationToken);
            await _repositoryProduto.Add(conhaque, cancellationToken);
            await _repositoryProduto.Add(suco, cancellationToken);
            await _repositoryProduto.Add(agua, cancellationToken);

            await _repositoryProduto.SaveChanges(cancellationToken);




            var PromoCerveja = new Domain.Entity.Promocao()
            {
                Id = 1,
                Desconto = 2,
                DescontoMaximo = false,
                ItemDesconto = cerveja,
                RepetirPromocao = true,
                ItensAtivadores = new Domain.Entity.PromocaoItem[]
                {
                new Domain.Entity.PromocaoItem()
                {
                    Id = 1,
                    Item = cerveja,
                    Quantidade = 1
                },
                new Domain.Entity.PromocaoItem()
                {
                    Id = 2,
                    Item = suco,
                    Quantidade = 1
                }
                }
            };

            var PromoAgua = new Domain.Entity.Promocao()
            {
                Id = 2,
                Desconto = 0,
                DescontoMaximo = true,
                ItemDesconto = agua,
                RepetirPromocao = false,
                ItensAtivadores = new Domain.Entity.PromocaoItem[]
                {
                new Domain.Entity.PromocaoItem()
                {
                    Id = 3,
                    Item = conhaque,
                    Quantidade = 3
                },
                new Domain.Entity.PromocaoItem()
                {
                    Id = 4,
                    Item = cerveja,
                    Quantidade = 2
                }
                }
            };

            await _repositoryPromocao.Add(PromoCerveja, cancellationToken);
            await _repositoryPromocao.Add(PromoAgua, cancellationToken);

            foreach (var item in PromoCerveja.ItensAtivadores.Union(PromoAgua.ItensAtivadores))
            {
                await _repositoryPromocaoItem.Add(item, cancellationToken);
            }

            await _repositoryPromocao.SaveChanges();
            await _repositoryPromocaoItem.SaveChanges();

            return Unit.Value;
        }
    }
}
