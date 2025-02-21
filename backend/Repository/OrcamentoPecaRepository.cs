using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class OrcamentoPecaRepository : IOrcamentoPecaRepository
    {
        private readonly AppDbContext _context;

        public OrcamentoPecaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrcamentoPecas>> GetAll()
        {
            return await _context.OrcamentoPecas
                .Include(op => op.Orcamento)
                .Include(op => op.Peca)
                .ToListAsync();
        }

        public async Task<List<OrcamentoPecas>> GetByOrcamentoId(int orcamentoId)
        {
            return await _context.OrcamentoPecas
                .Where(op => op.OrcamentoId == orcamentoId)
                .Include(op => op.Peca)
                .ToListAsync();
        }

        public async Task<OrcamentoPecas> GetById(int id)
        {
            return await _context.OrcamentoPecas
                .Include(op => op.Orcamento)
                .Include(op => op.Peca)
                .FirstOrDefaultAsync(op => op.Id == id);
        }

        public async Task<OrcamentoPecas> Add(OrcamentoPecas orcamentoPeca)
        {
            _context.OrcamentoPecas.Add(orcamentoPeca);
            _context.SaveChanges();
            return orcamentoPeca;
        }

        public async Task<OrcamentoPecas> Update(OrcamentoPecas orcamentoPeca)
        {
            var existingOrcamentoPeca = await _context.OrcamentoPecas.FindAsync(orcamentoPeca.Id);
            if (existingOrcamentoPeca == null)
                throw new ArgumentException("Registro não encontrado.");

            existingOrcamentoPeca.Quantidade = orcamentoPeca.Quantidade;
            existingOrcamentoPeca.Estado = orcamentoPeca.Estado;

            _context.SaveChanges();
            return existingOrcamentoPeca;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.OrcamentoPecas.FindAsync(id);
            if (entity == null)
                return false;

            _context.OrcamentoPecas.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> UpdateEstado(int id, EstadoPeca estado)
        {
            var newEstado = await _context.OrcamentoPecas.FindAsync(id);
            if (newEstado == null)
                return false;

            newEstado.Estado = estado;
            _context.SaveChanges();
            return true;
        }
    }
}