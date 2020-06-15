using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarDG.Service.Handler
{
    public class AddItemToComanda : IRequestHandler<Domain.Command.AddItemToComanda, Comanda>
    {
        private readonly IRepository<Comanda> _repositoryComanda;
        private readonly IRepository<Produto> _repositoryProduto;

        public AddItemToComanda(IRepository<Comanda> repositoryComanda, IRepository<Produto> repositoryProduto)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryProduto = repositoryProduto;
        }
        public async Task<Comanda> Handle(Domain.Command.AddItemToComanda request, CancellationToken cancellationToken)
        {
            var comanda = await _repositoryComanda.Get(request.ComandaId);
            comanda.Produtos.Add(await _repositoryProduto.Get(request.ItemId));

            return await _repositoryComanda.Update(comanda);
        }
    }
}
