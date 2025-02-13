using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly IAppDbContext _context;

        public OrcamentoRepository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Orcamento>> GetAll()
        {
            return await _context.Orcamentos.ToListAsync();
        }

        public async Task<Orcamento> GetById(int id)
        {
            var orcamento = await _context.Orcamentos
                        .Include(o => o.Pecas)
                        .ThenInclude(op => op.Peca)
                        .FirstOrDefaultAsync(o => o.Id == id);

            if (orcamento == null)
            {
                throw new ArgumentException("Orçamento não encontrado!");
            }

            return orcamento;
        }

        public async Task<Orcamento> GetByNumero(string numero)
        {
            var orcamento = await _context.Orcamentos
                        .Include(o => o.Pecas)
                        .ThenInclude(op => op.Peca)
                        .FirstOrDefaultAsync(o => o.Numero == numero);

            if (orcamento == null)
            {
                throw new ArgumentException("Orçamento não encontrado!");
            }

            return orcamento;
        }

        public async Task<Orcamento> Create(Orcamento orcamento)
        {
            var existingOrcamento = await _context.Orcamentos.FirstOrDefaultAsync(x => x.Numero == orcamento.Numero);

            if (existingOrcamento != null)
            {
                throw new ArgumentException("Orçamento já cadastrado!");
            }

            _context.Orcamentos.Add(orcamento);
            _context.SaveChanges();

            return orcamento;
        }
        
        public async Task<Orcamento> Update(Orcamento orcamento)
        {
            var existingOrcamento = await _context.Orcamentos.FindAsync(orcamento.Id);

            if (existingOrcamento == null)
            {
                throw new ArgumentException("Orçamento não encontrado!");
            }

            _context.Orcamentos.Update(orcamento);
            _context.SaveChanges();

            return orcamento;
        }

        public async Task<Orcamento> Delete(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);

            if (orcamento == null)
            {
                throw new ArgumentException("Orçamento não encontrado!");
            }

            _context.Orcamentos.Remove(orcamento);
            _context.SaveChanges();

            return orcamento;
        }
    }        
}