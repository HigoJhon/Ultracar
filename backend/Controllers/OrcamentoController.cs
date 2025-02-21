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
        private readonly IOrcamentoPecaRepository _orcamentoPecaRepository;
        private readonly IPecaRepository _pecaRepository;
        public OrcamentoController(IOrcamentoRepository repository, IOrcamentoPecaRepository orcamentoPecaRepository, IPecaRepository pecaRepository)
        {
            _repository = repository;
            _orcamentoPecaRepository = orcamentoPecaRepository;
            _pecaRepository = pecaRepository;
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
                return NotFound(new { message = "Orçamento não encontrado." });
            }
            return Ok(orcamento);
        }

        [HttpPost]
        public async Task<ActionResult<Orcamento>> Create([FromBody] OrcamentoCreateDTO orcamentoDTO)
        {
            var orcamento = new Orcamento
            {
                Numero = orcamentoDTO.Numero,
                Placa = orcamentoDTO.PlacaVeiculo,
                NameCliente = orcamentoDTO.NomeCliente
            };

            await _repository.Add(orcamento);

            foreach (var pecaDTO in orcamentoDTO.Pecas)
            {
                if (!await _pecaRepository.ExistInEstoque(pecaDTO.PecaId, pecaDTO.Quantidade))
                    return BadRequest(new { message = $"A peça {pecaDTO.PecaId} não possui estoque suficiente." });

                var orcamentoPeca = new OrcamentoPecas
                {
                    OrcamentoId = orcamento.Id,
                    PecaId = pecaDTO.PecaId,
                    Quantidade = pecaDTO.Quantidade,
                    Estado = EstadoPeca.EmEspera
                };
                await _orcamentoPecaRepository.Add(orcamentoPeca);
            }

            return CreatedAtAction(nameof(GetById), new { id = orcamento.Id }, orcamento);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrcamentoUpdateDTO orcamentoDTO)
        {
            var existingOrcamento = await _repository.GetById(id);
            if (existingOrcamento == null)
            {
                return NotFound(new { message = "Orçamento não encontrado." });
            }

            existingOrcamento.Numero = orcamentoDTO.Numero;
            existingOrcamento.Placa = orcamentoDTO.PlacaVeiculo;
            existingOrcamento.NameCliente = orcamentoDTO.NomeCliente;

            var existingPecas = await _orcamentoPecaRepository.GetByOrcamentoId(id);
            foreach (var peca in existingPecas)
            {
                await _orcamentoPecaRepository.Delete(peca.Id);
            }

            foreach (var pecaDTO in orcamentoDTO.Pecas)
            {
                if (!await _pecaRepository.ExistInEstoque(pecaDTO.PecaId, pecaDTO.Quantidade))
                    return BadRequest(new { message = $"A peça {pecaDTO.PecaId} não possui estoque suficiente." });

                var orcamentoPeca = new OrcamentoPecas
                {
                    OrcamentoId = id,
                    PecaId = pecaDTO.PecaId,
                    Quantidade = pecaDTO.Quantidade
                };
                await _orcamentoPecaRepository.Add(orcamentoPeca);
            }

            await _repository.Update(existingOrcamento);
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