using backend.Models;
using backend.Repository;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntregaController : Controller
    {
        private readonly IEntregaService _service;
        private readonly IEntregaRepository _repository;
        
        public EntregaController(IEntregaService service, IEntregaRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Entrega>> CriarEntrega([FromBody] Entrega entrega)
        {
            if (string.IsNullOrEmpty(entrega.Cep))
                return BadRequest("CEP não pode ser vazio.");

            var endereco = await _service.ObterEnderecoPorCep(entrega.Cep);

            if (endereco == null)
                return NotFound("Endereço não encontrado.");

            entrega.Endereco = endereco.Endereco;
            await _repository.AdicionarEntrega(entrega);

            return Ok(entrega);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entrega>> ObterEntregaPorId(int id)
        {
            var entrega = await _repository.ObterEntregaPorId(id);
            if (entrega == null)
                return NotFound("Entrega não encontrada.");

            return Ok(entrega);
        }
    }
}
