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
    public class AddItemToComanda : IRequestHandler<Domain.Command.AddItemToComanda, Comanda>
    {
        private readonly IRepository<Comanda> _repositoryComanda;
        private readonly IRepository<Produto> _repositoryProduto;
        private readonly IRepository<Item> _repositoryItem;

        public AddItemToComanda(IRepository<Comanda> repositoryComanda, IRepository<Produto> repositoryProduto, IRepository<Item> repositoryItem)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryProduto = repositoryProduto;
            _repositoryItem = repositoryItem;
        }
        public async Task<Comanda> Handle(Domain.Command.AddItemToComanda request, CancellationToken cancellationToken)
        {
            var comanda = await _repositoryComanda.Get(request.ComandaId, cancellationToken: cancellationToken);

            if (comanda.Itens.Any(x => x.Produto.Id == request.ProductId))
            {
                foreach (var itemNaComanda in comanda.Itens)
                {
                    if (itemNaComanda.Produto.Id == request.ProductId)
                    {
                        itemNaComanda.Quantidade++;
                        await _repositoryItem.Update(itemNaComanda);
                    }
                }
            }
            else
            {
                var item = new Item(await _repositoryProduto.Get(request.ProductId,cancellationToken: cancellationToken));

                comanda.Itens.Add(item);

                await _repositoryItem.Add(item, cancellationToken: cancellationToken);
            }

            await _repositoryComanda.SaveChanges(cancellationToken);

            return comanda;
        }
    }
}
