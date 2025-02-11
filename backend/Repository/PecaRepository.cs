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
            if(existPeca == null)
            {
                throw new ArgumentException("Peça não encontrada!");
            }
            return existPeca;
        }

        public async Task<Peca> Add(Peca peca)
        {
            var existingPeca = await _context.Pecas.FirstOrDefaultAsync(x => x.Nome == peca.Nome);
            if (existingPeca != null)
            {
                throw new ArgumentException("Peça já cadastrada!");
            }

            _context.Pecas.Add(peca);
            _context.SaveChanges();

            return peca;
        }

        public async Task<Peca> Update(Peca peca)
        {
            var existPeca = await _context.Pecas.FindAsync(peca.Id);
            if (existPeca == null)
            {
                throw new ArgumentException("Peça não encontrada!");
            }

            _context.Pecas.Update(peca);
            _context.SaveChanges();
            
            return peca;
        }

        public async Task<Peca> Delete(int id)
        {
            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null)
            {
                throw new ArgumentException("Peça não encontrada!");
            }
            
            _context.Pecas.Remove(peca);
            _context.SaveChanges();

            return peca;
        }
    }
}
