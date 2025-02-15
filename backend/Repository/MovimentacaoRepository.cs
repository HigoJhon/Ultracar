using backend.Context;
using backend.Models;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class MovimentacaoEstoqueRepository : IMovimentacaoEstoqueRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> GetAll()
        {
            return await _context.MovimentacoesEstoque.Include(m => m.Peca).ToListAsync();
        }

        public async Task<MovimentacaoEstoque> GetById(int id)
        {
            return await _context.MovimentacoesEstoque
                .Include(m => m.Peca)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Add(MovimentacaoEstoque movimentacao)
        {
            await _context.MovimentacoesEstoque.AddAsync(movimentacao);
        }

        public async Task<bool> SalvarAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}