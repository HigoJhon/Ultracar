using backend.Dto;
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
        public async Task<ActionResult<MovimentacaoEstoque>> Adicionar([FromBody] MovimentacaoEstoqueCreateDTO movimentacaoDTO)
        {
            var movimentacao = new MovimentacaoEstoque
            {
                PecaId = movimentacaoDTO.PecaId,
                Quantidade = movimentacaoDTO.Quantidade,
                tipoMovimentacao = movimentacaoDTO.tipoMovimentacao
            };

            var addedMovimentacao = await _repository.Add(movimentacao); 
            return CreatedAtAction(nameof(ObterPorId), new { id = addedMovimentacao.Id }, addedMovimentacao); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovimentacaoEstoqueUpdateDTO movimentacaoDTO)
        {
            var existingMovimentacao = await _repository.GetById(id);
            if (existingMovimentacao == null)
            {
                return NotFound(new { message = "Movimentação não encontrada." });
            }

            existingMovimentacao.PecaId = movimentacaoDTO.PecaId;
            existingMovimentacao.Quantidade = movimentacaoDTO.Quantidade;
            existingMovimentacao.tipoMovimentacao = movimentacaoDTO.tipoMovimentacao;

            var updatedMovimentacao = await _repository.Update(existingMovimentacao);

            return Ok(updatedMovimentacao);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var movimentacao = await _repository.GetById(id);
            if (movimentacao == null)
            {
                return NotFound(new { message = "Movimentação não encontrada." });
            }

            return NoContent();
        }
    }
}