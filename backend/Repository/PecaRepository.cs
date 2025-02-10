using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PecaRepository : IPecaRepository
    {
        private readonly IAppDbContext _context;
        public PecaRepository(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Peca>> GetAll()
        {
            return await _context.Pecas.ToListAsync();
        }

        public async Task<Peca> GetPeca(int id)
        {
            var existPeca = await _context.Pecas.FindAsync(id);
            if (existPeca == null)
            {
                throw new ArgumentException("Peça não encontrada!");
            }

            return existPeca;
        }
    }
}
