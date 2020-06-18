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
    public class GenerateNotaFiscal : IRequestHandler<Domain.Command.GenerateNotaFiscal, NotaFiscal>
    {
        private readonly IRepository<Comanda> _repositoryComanda;
        private readonly IRepository<NotaFiscal> _repositoryNotaFiscal;

        public GenerateNotaFiscal(IRepository<Comanda> repositoryComanda, IRepository<NotaFiscal> repositoryNotaFiscal)
        {
            this._repositoryComanda = repositoryComanda;
            this._repositoryNotaFiscal = repositoryNotaFiscal;
        }

        public async Task<NotaFiscal> Handle(Domain.Command.GenerateNotaFiscal request, CancellationToken cancellationToken)
        {
            var comanda = await _repositoryComanda.Get(request.ComandaId, cancellationToken: cancellationToken);

            var notaFiscal = new NotaFiscal(comanda);

            if (notaFiscal.Invalid)
                return notaFiscal;
            await _repositoryNotaFiscal.Add(notaFiscal, cancellationToken);

            await _repositoryNotaFiscal.SaveChanges(cancellationToken);

            await _repositoryComanda.Remove(comanda);

            await _repositoryComanda.SaveChanges(cancellationToken);

            return notaFiscal;
        }
    }
}
