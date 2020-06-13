using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllProdutos()
        {
            return Ok(new List<Domain.Entity.Produto> { 
                new Domain.Entity.Produto
                {
                    Valor = 99,
                    Descricao = "teste prod 1"
                },
                new Domain.Entity.Produto
                {
                    Valor = 10,
                    Descricao = "teste prod 2"
                }
            }); 
        }
    }
}
