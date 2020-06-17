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
    public class ResetComanda : IRequestHandler<Domain.Command.ResetComanda, Comanda>
    {
        private readonly IRepository<Comanda> _repositoryComanda;
        private readonly IRepository<Item> _repositoryItem;

        public ResetComanda(IRepository<Comanda> repositoryComanda, IRepository<Item> repositoryItem)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryItem = repositoryItem;
        }
        public async Task<Comanda> Handle(Domain.Command.ResetComanda request, CancellationToken cancellationToken)
        {
            var comanda = await _repositoryComanda.Get(request.ComandaId);

            await _repositoryItem.RemoveRange(comanda.Itens);

            comanda.Reset();

            await _repositoryComanda.Update(comanda);

            await _repositoryComanda.SaveChanges();

            return await comanda;         
        }
    }
}
