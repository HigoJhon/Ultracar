using backend.Dto;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoPecaController : Controller
    {
        private readonly IOrcamentoPecaRepository _repository;

        public OrcamentoPecaController(IOrcamentoPecaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrcamentoPecas>>> GetAll()
        {
            var orcamentoPecas = await _repository.GetAll();
            return Ok(orcamentoPecas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrcamentoPecas>> GetById(int id)
        {
            var orcamentoPeca = await _repository.GetById(id);
            if (orcamentoPeca == null)
            {
                return NotFound();
            }
            return Ok(orcamentoPeca);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PecaOrcamentoCreateDTO orcamentoPecaDto)
        {
            var orcamentoPecaModel = new OrcamentoPecas
            {
                OrcamentoId = orcamentoPecaDto.OrcamentoId,
                PecaId = orcamentoPecaDto.PecaId,
                Quantidade = orcamentoPecaDto.Quantidade,
                Estado = EstadoPeca.EmEspera
            };

            await _repository.Add(orcamentoPecaModel);

            return Created("", orcamentoPecaModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] PecaOrcamentoUpdateDTO orcamentoPecaDto, int id)
        {
            var existOrcamento = await _repository.GetById(id);
            if (existOrcamento == null)
            {
                return NotFound("Relação Orçamento-Peça não encontrada.");
            }

            existOrcamento.OrcamentoId = orcamentoPecaDto.OrcamentoId;
            existOrcamento.PecaId = orcamentoPecaDto.PecaId;
            existOrcamento.Quantidade = orcamentoPecaDto.Quantidade;
            existOrcamento.Estado = orcamentoPecaDto.Estado;

            await _repository.Update(existOrcamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}/estado")]
        public async Task<ActionResult> UpdateEstado(int id, [FromBody] EstadoPeca estado)
        {
            var updated = await _repository.UpdateEstado(id, estado);
            if (!updated) return NotFound("Relação Orçamento-Peça não encontrada.");
            return NoContent();
        }
    }
}
