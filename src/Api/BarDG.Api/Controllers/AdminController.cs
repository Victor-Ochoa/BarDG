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
    public class AdminController : ControllerBase
    {

        [HttpPost]
        [Route("RunInitialData")]
        public async Task<IActionResult> RunInitialData([FromServices] IMediator _mediator) => Ok(await _mediator.Send(new Domain.Command.InitialDate()));
    }
}
