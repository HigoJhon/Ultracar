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
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetAll()
        {
            var orcamentos = await _repository.GetAll();    
            return Ok(orcamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orcamento>> GetById(int id)
        {
            var orcamento = await _repository.GetById(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return Ok(orcamento);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrcamentoDTO orcamento)
        {
            var orcamentoModel = new Orcamento
            {
                Numero = orcamento.Numero,
                Placa = orcamento.PlacaVeiculo,
                NameCliente = orcamento.NomeCliente,
                Pecas = orcamento.Pecas.Select(x => new OrcamentoPecas
                {
                    PecaId = x.PecaId,
                    Quantidade = x.Quantidade,
                    Estado = EstadoPeca.EmEspera
                }).ToList()
            };

            await _repository.Add(orcamentoModel);

            return Created("", orcamentoModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] OrcamentoDTO orcamento, int id)
        {
            var existingOrcamento = await _repository.GetById(id);
            if (existingOrcamento == null)
            {
                return NotFound("Orçamento não encontrado.");
            }

            var orcamentoModel = new Orcamento
            {
                Id = id,
                Numero = orcamento.Numero,
                Placa = orcamento.PlacaVeiculo,
                NameCliente = orcamento.NomeCliente,
                Pecas = orcamento.Pecas.Select(x => new OrcamentoPecas
                {
                    PecaId = x.PecaId,
                    Quantidade = x.Quantidade
                }).ToList()
            };

            await _repository.Update(orcamentoModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}