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

        public async Task<Peca> Update(int id, Peca peca)
        {
            var exist =  await _context.Pecas.FindAsync(id);
            if(exist == null)
            throw new ArgumentException("Peça não existe!");
            
            exist.Nome = peca.Nome == "" ? exist.Nome : peca.Nome;
            exist.Estoque = peca.Estoque == 0 ? exist.Estoque : peca.Estoque;
            exist.Preco = peca.Preco == 0 ? exist.Preco : peca.Preco;

            _context.SaveChanges();
            
            return peca;
        }

        public async Task<Peca> Delete(int id)
        {
            var peca = await GetById(id);
            if (peca == null)
                throw new ArgumentException("Peça nao encontrada!");

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