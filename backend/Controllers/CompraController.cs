using backend.Dto;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _repository;

        public CompraController(ICompraRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetAll()
        {
            var compras = await _repository.GetAll();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compras>> GetById(int id)
        {
            var compra = await _repository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }

        [HttpPost]
        public async Task<ActionResult<Compras>> Create([FromBody] CompraDTO compra)
        {
            var compraModel = new Compras
            {
                PecaId = compra.PecaId,
                Quantidade = compra.Quantidade,
                PrecoCusto = compra.PrecoCusto,
                DataCompra = compra.DataCompra
            };

            await _repository.Add(compraModel);
            return Created("", compraModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Compras>> Update(int id, [FromBody] CompraDTO compraDto)
        {
            var compra = await _repository.GetById(id);
            if (compra == null)
            {
                return NotFound();
            }

            compra.PecaId = compraDto.PecaId;
            compra.Quantidade = compraDto.Quantidade;
            compra.PrecoCusto = compraDto.PrecoCusto;
            compra.DataCompra = compraDto.DataCompra;

            var updatedCompra = await _repository.Update(compra);
            return Ok(updatedCompra);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var compra = await _repository.Delete(id);
            if (compra == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
