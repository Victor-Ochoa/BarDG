using BarDG.Domain.Entity;
using MediatR;

namespace BarDG.Domain.Command
{
    public class GenerateNotaFiscal: IRequest<NotaFiscal>
    {
        public int ComandaId { get; set; }
    }
}
