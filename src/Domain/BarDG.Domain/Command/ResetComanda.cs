﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Command
{
    public class ResetComanda : IRequest<Entity.Comanda>
    {
        public int ComandaId { get; set; }
    }
}
