using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoEstoqueRepository _repository;
        public MovimentacaoController(IMovimentacaoEstoqueRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentacaoEstoque>>> ObterTodas()
        {
            var movimentacoes = await _repository.GetAll();
            return Ok(movimentacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimentacaoEstoque>> ObterPorId(int id)
        {
            var movimentacao = await _repository.GetById(id);
            if (movimentacao == null)
                return NotFound("Movimentação não encontrada.");

            return Ok(movimentacao);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] MovimentacaoEstoque movimentacao)
        {
            if (movimentacao == null)
                return BadRequest("Dados inválidos.");

            await _repository.Add(movimentacao);
            var sucesso = await _repository.SalvarAsync();

            if (!sucesso)
                return StatusCode(500, "Erro ao salvar movimentação.");

            return CreatedAtAction(nameof(ObterPorId), new { id = movimentacao.Id }, movimentacao);
        }
    }
}