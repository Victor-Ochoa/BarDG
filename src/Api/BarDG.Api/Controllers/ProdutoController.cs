using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDG.Domain.Interface;
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
        public async Task<IActionResult> GetAllProdutos([FromServices] IRepository<Domain.Entity.Produto> repository)
        {
            return Ok(await repository.GetAll(asNoTracking: true)); 
        }
    }
}
