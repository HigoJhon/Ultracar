using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PecaRepository : IPecaRepository
    {
        private readonly IAppContext _context;
        public PecaRepository(IAppContext context)
        {
            _context = context;
        }

        public async Task<List<Peca>> GetAll()
        {
            return await _context.Pecas.ToListAsync();
        }

        public async Task<Peca> GetPeca(int id)
        {
            return await _context.Pecas.FindAsync(id);
        }
    }
}
