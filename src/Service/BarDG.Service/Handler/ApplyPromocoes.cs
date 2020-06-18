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
    public class ApplyPromocoes : IRequestHandler<Domain.Command.ApplyPromocoes, Comanda>
    {
        private readonly IRepository<Comanda> _repositoryComanda;
        private readonly IRepository<Promocao> _repositoryPromocao;

        public ApplyPromocoes(IRepository<Comanda> repositoryComanda, IRepository<Promocao> repositoryPromocao)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryPromocao = repositoryPromocao;
        }

        public async Task<Comanda> Handle(Domain.Command.ApplyPromocoes request, CancellationToken cancellationToken)
        {
            request.Comanda.zerarDesconto();

            var listPromocoes = await _repositoryPromocao.GetAll(cancellationToken: cancellationToken);

            foreach (var promocao in listPromocoes)
            {
                request.Comanda.AplicarPromo(promocao);
            }

            await _repositoryComanda.Update(request.Comanda);

            await _repositoryComanda.SaveChanges();

            return request.Comanda;
        }
    }
}
