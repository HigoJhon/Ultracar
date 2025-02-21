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

        public async Task<MovimentacaoEstoque> Add(MovimentacaoEstoque movimentacao)
        {
            await _context.MovimentacoesEstoque.AddAsync(movimentacao);
            _context.SaveChanges();
            return movimentacao;
        }

        public async Task<MovimentacaoEstoque> Update(MovimentacaoEstoque movimentacao)
        {
            var existingMovimentacao = await _context.MovimentacoesEstoque.FindAsync(movimentacao.Id);
            if (existingMovimentacao == null)
                throw new ArgumentException("Movimentação não encontrada.");

            existingMovimentacao.PecaId = movimentacao.PecaId;
            existingMovimentacao.Quantidade = movimentacao.Quantidade;
            existingMovimentacao.Data = movimentacao.Data;
            existingMovimentacao.tipoMovimentacao = movimentacao.tipoMovimentacao;

            await _context.SaveChangesAsync();
            return existingMovimentacao;
        }

        public async Task<bool> Delete(int id)
        {
            var movimentacao = await _context.MovimentacoesEstoque.FindAsync(id);
            if (movimentacao == null)
                return false;

            _context.MovimentacoesEstoque.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}