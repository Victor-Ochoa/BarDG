using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDG.Domain.Command;
using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        [HttpPost]
        [Route("Generate")]
        public async Task<IActionResult> GenerateNotaFiscal([FromBody] GenerateNotaFiscal generateNotaFiscal, [FromServices] IMediator _mediator) => Ok(await _mediator.Send(generateNotaFiscal));

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllNotaFiscal([FromServices] IRepository<NotaFiscal> repository) => Ok(await repository.GetAll());

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetNotaFiscal([FromServices] IRepository<NotaFiscal> repository, [FromRoute] int id) => Ok(await repository.Get(id));
    }
}
