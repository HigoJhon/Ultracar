using backend.Dto;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult> Create(PecaCreateDTO pecaDto)
        {
            var peca = new Peca
            {
                Nome = pecaDto.Nome!,
                Estoque = pecaDto.Estoque,
                Preco = pecaDto.Preco
            };

            await _repository.Add(peca);
            return Ok(peca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PecaCreateDTO pecaDto)
        {
            var updatePeca = new Peca
            {
                Nome = pecaDto.Nome!,
                Estoque = pecaDto.Estoque,
                Preco = pecaDto.Preco
            };

            await _repository.Update(id, updatePeca);
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