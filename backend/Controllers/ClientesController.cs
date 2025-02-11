using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientesController : Controller
    {
        private readonly IClientesRepository _repository;
        public ClientesController(IClientesRepository repository)
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
            return Ok(await _repository.GetCliente(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Clientes cliente)
        {

            var newCliente = await _repository.Add(cliente);
            return Ok(newCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Clientes cliente)
        {
            var clienteExist = await _repository.GetCliente(id);

            if (clienteExist == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            clienteExist.Nome = cliente.Nome != "" ? cliente.Nome : clienteExist.Nome;
            clienteExist.Email = cliente.Email != "" ? cliente.Email : clienteExist.Email;
            clienteExist.Telefone = cliente.Telefone != "" ? cliente.Telefone : clienteExist.Telefone;

            var updatedCliente = await _repository.Update(clienteExist);
            return Ok(updatedCliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _repository.GetCliente(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }

            return Ok(await _repository.Delete(id));
        }
    }
}