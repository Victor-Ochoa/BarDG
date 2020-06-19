using System.Threading.Tasks;
using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromServices] IRepository<Comanda> _repository) => Ok(await _repository.GetAll(asNoTracking: true));
        [HttpGet]
        [Route("{comandaId:int}")]
        public async Task<IActionResult> Get([FromServices] IRepository<Comanda> _repository,[FromRoute] int comandaId) => Ok(await _repository.Get(comandaId));

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateNewComanda([FromServices] IMediator _mediator) => Ok(await _mediator.Send(new Domain.Command.CreateNewComanda()));


        [HttpPost]
        [Route("AddItemToComanda")]
        public async Task<IActionResult> AddItemToComanda([FromServices] IMediator _mediator, [FromBody] Domain.Command.AddItemToComanda addItemToComanda) => Ok(await _mediator.Send(addItemToComanda));
        
        [HttpPost]
        [Route("ResetComanda")]
        public async Task<IActionResult> ResetComanda([FromServices] IMediator _mediator, [FromBody] Domain.Command.ResetComanda resetComanda) => Ok(await _mediator.Send(resetComanda));
    }
}
