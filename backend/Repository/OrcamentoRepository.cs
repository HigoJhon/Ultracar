using backend.Context;
using backend.Models;

namespace backend.Repository
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly IAppDbContext _context;

        public OrcamentoRepository(IAppDbContext context)
        {
            _context = context;
        }
    
        public async Task<Orcamento> GetById(int id)
        {
            var orcamento = await _context.Orcamentos.FindAsync(id);
            if (orcamento == null)
            {
                throw new ArgumentException("Orçamento não encontrado!");
            }
            return orcamento;
        }
    }        
}