using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("pecas")]

    public class PecaController : Controller
    {
        private readonly IPecaRepository _repository;
        public PecaController(IPecaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await _repository.GetPeca(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Peca peca)
        {

            var newPeca = await _repository.Add(peca);
            return Ok(newPeca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Peca peca)
        {
            var pecaExist = await _repository.GetPeca(id);

            if (pecaExist == null)
            {
                return NotFound("Peça não encontrada!");
            }

            pecaExist.Nome = peca.Nome != "" ? peca.Nome : pecaExist.Nome;
            pecaExist.Estoque = peca.Estoque != 0 ? peca.Estoque : pecaExist.Estoque;
            pecaExist.Preco = peca.Preco != 0 ? peca.Preco : pecaExist.Preco;
            
            var updatedPeca = await _repository.Update(pecaExist);
            return Ok(updatedPeca);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var peca = await _repository.GetPeca(id);
            if (peca == null)
            {
                return NotFound("Peça não encontrada!");
            }

            await _repository.Delete(id);
            return Ok("Peça deletada com sucesso!");
        }
    }
}