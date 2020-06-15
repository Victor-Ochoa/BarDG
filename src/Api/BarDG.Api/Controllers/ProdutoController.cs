using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDG.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProdutos([FromServices] IMediator mediator) => Ok(await mediator.Send(new Domain.Command.GetAllProdutos()));
    }
}
