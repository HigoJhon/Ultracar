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
       
        public async Task<Peca> GetById(int id)
        {
            return await _context.Pecas.FindAsync(id);
        }

        public async Task<Peca> Add(Peca peca)
        {
            await _context.Pecas.AddAsync(peca);
            _context.SaveChanges();
            return peca;
        }

        public async Task<Peca> Update(Peca peca)
        {
             var exist =  await _context.Orcamentos.FindAsync(peca.Id);
            if(exist == null)
            throw new ArgumentException("Peça não existe!");
            
            _context.Pecas.Update(peca);
            _context.SaveChanges();
            
            return peca;
        }

        public async Task<Peca> Delete(int id)
        {
            var peca = await GetById(id);
            if (peca == null)
                return null;

            _context.Pecas.Remove(peca);
            _context.SaveChanges();
            return peca;
        }

        public async Task<bool> ExistInEstoque(int pecaId, int quantidade)
        {
            var peca = await GetById(pecaId);
            return peca != null && peca.Estoque >= quantidade;
        }

        public async Task updateEstoque(int pecaId, int quantidade)
        {
            var peca = await GetById(pecaId);
            if (peca != null)
            {
                peca.Estoque -= quantidade;
                _context.SaveChanges();
            }
        }
    }
}