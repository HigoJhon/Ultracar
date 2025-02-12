using backend.Models;

namespace backend.Repository
{
    public interface IOrcamentoRepository
    {
        Task<Orcamento> GetById(int id);
        Task<Orcamento> GetByNumero(string numero);
        Task<IEnumerable<Orcamento>> GetAll();
        Task Create(Orcamento orcamento);
        Task Update(Orcamento orcamento);
        Task Delete(int id);
    }
}