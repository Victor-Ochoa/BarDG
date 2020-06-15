using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Command
{
    public class AddItemToComanda : IRequest<Entity.Comanda>
    {
        public Guid ComandaId { get; set; }
        public Guid ItemId { get; set; }
    }
}
