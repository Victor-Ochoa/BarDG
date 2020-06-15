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
    public class GetAllProdutos : IRequestHandler<Domain.Command.GetAllProdutos, List<Produto>>
    {
        private readonly IRepository<Produto> _repository;

        public GetAllProdutos(IRepository<Produto> repository)
        {
            this._repository = repository;
        }
        public Task<List<Produto>> Handle(Domain.Command.GetAllProdutos request, CancellationToken cancellationToken) => 
            _repository.GetAll(asNoTracking: true);
    }
}
