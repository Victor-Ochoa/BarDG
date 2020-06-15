using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Command
{
    public class CreateNewComanda : IRequest<Entity.Comanda>
    {
    }
}
