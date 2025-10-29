using Microsoft.AspNetCore.Mvc;
using Inventory.Api.Models;
using Inventory.Api.Services;
using Inventory.Api.Data;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                _service.CadastrarProduto(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
