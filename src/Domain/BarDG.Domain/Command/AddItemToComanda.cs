using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Command
{
    public class AddItemToComanda : IRequest<Entity.Comanda>
    {
        public int ComandaId { get; set; }
        public int ProductId { get; set; }
    }
}
