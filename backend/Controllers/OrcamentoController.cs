using backend.Dto;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoRepository _repository;
        public OrcamentoController(IOrcamentoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orcamento = await _repository.GetById(id);
            if (orcamento == null)
            return NotFound();

            return Ok(orcamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrcamentoDTO orcamento)
        {
            var newOrcamento = new Orcamento
            {
              Numero = orcamento.Numero,
              Placa = orcamento.PlacaVeiculo,
              NameCliente = orcamento.NomeCliente,
              Pecas = orcamento.Pecas.Select(p => new OrcamentoPecas 
              {
                PecaId = p.PecaId,
                Quantidade = p.Quantidade,
                Status = "Em Espera",
              }).ToList()
            };

            await _repository.Create(newOrcamento);
            return Created("", newOrcamento);
        }
    }
}