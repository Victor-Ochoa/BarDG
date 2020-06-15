using System.Threading.Tasks;
using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromServices] IRepository<Comanda> _repository) => Ok(await _repository.GetAll(asNoTracking: true));

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateNewComanda([FromServices] IMediator _mediator) => Ok(await _mediator.Send(new Domain.Command.CreateNewComanda()));


        [HttpPost]
        [Route("addItemToComanda")]
        public async Task<IActionResult> AddItemToComanda([FromServices] IMediator _mediator, [FromBody] Domain.Command.AddItemToComanda addItemToComanda) => Ok(await _mediator.Send(addItemToComanda));
    }
}
