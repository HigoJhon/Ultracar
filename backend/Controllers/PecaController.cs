using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PecaController : Controller
    {
        private readonly IPecaRepository _repository;
        public PecaController(IPecaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peca>>> GetAll()
        {
            var pecas = await _repository.GetAll();
            return Ok(pecas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Peca>> GetById(int id)
        {
            var peca = await _repository.GetById(id);
            if (peca == null)
                return NotFound("Peça não encontrada.");
            return Ok(peca);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Peca peca)
        {
            await _repository.Add(peca);
            return CreatedAtAction(nameof(GetById), new { id = peca.Id }, peca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Peca peca)
        {
            if (id != peca.Id)
                return BadRequest("ID da peça não corresponde.");

            var existingPeca = await _repository.GetById(id);
            if (existingPeca == null)
                return NotFound("Peça não encontrada.");

            existingPeca.Nome = peca.Nome;
            existingPeca.Estoque = peca.Estoque;
            existingPeca.Preco = peca.Preco;

            await _repository.Update(existingPeca);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var peca = await _repository.GetById(id);
            if (peca == null)
                return NotFound("Peça não encontrada.");

            await _repository.Delete(id);
            return NoContent();
        }
    }
}