using BarDG.Domain.Entity;
using MediatR;

namespace BarDG.Domain.Command
{
    public class ApplyPromocoes : IRequest<Comanda>
    {
        public Comanda Comanda { get; set; }
    }
}
