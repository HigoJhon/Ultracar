using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly AppDbContext _context;

        public EntregaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Entrega> AdicionarEntrega(Entrega entrega)
        {
            await _context.Entregas.AddAsync(entrega);
            return entrega;
        }

        public async Task<Entrega> ObterEntregaPorId(int id)
        {
            return await _context.Entregas.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}