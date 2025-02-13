using backend.Models;

namespace backend.Repository
{
    public interface IOrcamentoRepository
    {
        Task<Orcamento> GetById(int id);
        Task<Orcamento> GetByNumero(string numero);
        Task<IEnumerable<Orcamento>> GetAll();
        Task<Orcamento> Create(Orcamento orcamento);
        Task<Orcamento> Update(Orcamento orcamento);
        Task<Orcamento> Delete(int id);
    }
}