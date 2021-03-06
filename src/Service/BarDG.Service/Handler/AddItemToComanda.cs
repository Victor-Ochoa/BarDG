﻿using BarDG.Domain.Entity;
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
        private readonly IRepository<ComandaItem> _repositoryItem;
        private readonly IMediator _mediator;

        public AddItemToComanda(IRepository<Comanda> repositoryComanda, IRepository<Produto> repositoryProduto, IRepository<ComandaItem> repositoryItem, IMediator mediator)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryProduto = repositoryProduto;
            _repositoryItem = repositoryItem;
            this._mediator = mediator;
        }
        public async Task<Comanda> Handle(Domain.Command.AddItemToComanda request, CancellationToken cancellationToken)
        {
            var comanda = await _repositoryComanda.Get(request.ComandaId, cancellationToken: cancellationToken);

            var produto = await _repositoryProduto.Get(request.ProductId, cancellationToken: cancellationToken);

            comanda.AddItem(produto);

            if (comanda.Invalid)
                return comanda;

            foreach (var item in comanda.Itens)
            {
                await _repositoryItem.AddOrUpdate(item, cancellationToken: cancellationToken);
            }

            await _repositoryItem.SaveChanges(cancellationToken);

            comanda = await _mediator.Send(new Domain.Command.ApplyPromocoes() { Comanda = comanda });

            return comanda;
        }
    }
}
