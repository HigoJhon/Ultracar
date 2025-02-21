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
            return await _context.Orcamentos
                        .Include(o => o.Pecas)
                        .ThenInclude(op => op.Peca)
                        .ToListAsync();
        }

        public async Task<Orcamento?> GetById(int id)
        {
            return await _context.Orcamentos
                .Include(o => o.Pecas)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Add(Orcamento orcamento)
        {
            await _context.Orcamentos.AddAsync(orcamento);
            _context.SaveChanges();
        }

        public async Task Update(Orcamento orcamento)
        {
            var exist =  await _context.Orcamentos.FindAsync(orcamento.Id);
            if(exist == null)
            throw new ArgumentException("Orçamento não existe!");

            exist.Numero = orcamento.Numero == 0 ? exist.Numero : orcamento.Numero;
            exist.Placa = orcamento.Placa == "" ? exist.Placa : orcamento.Placa;
            exist.NameCliente = orcamento.NameCliente == "" ? exist.NameCliente : orcamento.NameCliente;

            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);
            if (orcamento == null)
                throw new DllNotFoundException("Orçamento não encontrado.");
            
            _context.Orcamentos.Remove(orcamento);
            _context.SaveChanges();
        }
    }        
}