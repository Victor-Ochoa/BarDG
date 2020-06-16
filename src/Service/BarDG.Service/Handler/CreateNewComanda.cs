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
    public class CreateNewComanda : IRequestHandler<Domain.Command.CreateNewComanda, Comanda>
    {
        private readonly IRepository<Comanda> _repository;

        public CreateNewComanda(IRepository<Comanda> repository)
        {
            this._repository = repository;
        }
        public async Task<Comanda> Handle(Domain.Command.CreateNewComanda request, CancellationToken cancellationToken)
        {
            var comanda = new Comanda();

            await _repository.Add(comanda);

            await _repository.SaveChanges();

            return comanda;
        }
    }
}
