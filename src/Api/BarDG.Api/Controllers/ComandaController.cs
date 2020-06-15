using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {

        [HttpPut]
        [Route("Create")]
        public async Task<IActionResult> CreateNewComanda([FromServices] IMediator mediator) => Ok(await mediator.Send(new Domain.Command.CreateNewComanda()));


        [HttpPost]
        [Route("addItemToComanda")]
        public async Task<IActionResult> AddItemToComanda([FromServices] IMediator mediator, [FromBody] Domain.Command.AddItemToComanda addItemToComanda) => Ok(await mediator.Send(addItemToComanda));
    }
}
