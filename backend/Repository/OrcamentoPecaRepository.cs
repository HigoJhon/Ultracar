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
            await _context.SaveChangesAsync();
            return orcamentoPeca;
        }

        public async Task<OrcamentoPecas> Update(OrcamentoPecas orcamentoPeca)
        {
            _context.OrcamentoPecas.Update(orcamentoPeca);
            await _context.SaveChangesAsync();
            return orcamentoPeca;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.OrcamentoPecas.FindAsync(id);
            if (entity == null)
                return false;

            _context.OrcamentoPecas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEstado(int id, string estado)
        {
            var newEstado = await _context.OrcamentoPecas.FindAsync(id);
            if (newEstado == null)
                return false;

            newEstado.Estado = EstadoPeca.EmEspera;
            _context.OrcamentoPecas.Update(newEstado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}