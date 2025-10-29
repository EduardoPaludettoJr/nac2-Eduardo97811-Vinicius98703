using Microsoft.AspNetCore.Mvc;
using Inventory.Api.Services;
using Inventory.Api.Data;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _service;
        public RelatorioController(RelatorioService service)
        {
            _service = service;
        }

        [HttpGet("valor-total")]
        public IActionResult ValorTotal()
        {
            return Ok(_service.ValorTotalEstoque());
        }

        [HttpGet("vencendo-em-7-dias")]
        public IActionResult VencendoEm7Dias()
        {
            return Ok(_service.ProdutosVencendoEm7Dias());
        }

        [HttpGet("abaixo-minimo")]
        public IActionResult AbaixoMinimo()
        {
            return Ok(_service.ProdutosAbaixoMinimo());
        }
    }
}
