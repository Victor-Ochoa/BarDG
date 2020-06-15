using System.Threading.Tasks;
using BarDG.Domain.Entity;
using BarDG.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProdutos([FromServices] IRepository<Produto> _repository) => Ok( await _repository.GetAll(asNoTracking: true));
    }
}
