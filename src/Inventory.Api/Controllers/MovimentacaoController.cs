using Microsoft.AspNetCore.Mvc;
using Inventory.Api.Models;
using Inventory.Api.Services;
using Inventory.Api.Data;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly MovimentacaoService _service;
        public MovimentacaoController(MovimentacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovimentacaoEstoque mov)
        {
            try
            {
                _service.RegistrarMovimentacao(mov);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
