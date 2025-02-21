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
            _context.SaveChanges();
            return entrega;
        }

        public async Task<Entrega> ObterEntregaPorId(int id)
        {
            var entrega = await _context.Entregas
                .Include(e => e.Orcamento)
                .FirstOrDefaultAsync(e => e.Id == id);
        
            if (entrega == null)
                throw new ArgumentException("Entrega não encontrada.");
        
            return entrega;
        }

        public async Task<IEnumerable<Entrega>> ObterTodasEntregas()
        {
            return await _context.Entregas
                .Include(e => e.Orcamento)
                .ToListAsync();
        }
    }
}