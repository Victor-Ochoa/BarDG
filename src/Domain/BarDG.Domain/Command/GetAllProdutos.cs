using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Command
{
    public class GetAllProdutos: IRequest<List<Entity.Produto>>
    {}
}
