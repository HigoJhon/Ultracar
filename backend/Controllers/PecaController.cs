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
    }
}