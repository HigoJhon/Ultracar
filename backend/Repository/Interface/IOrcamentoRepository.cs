using backend.Models;

namespace backend.Repository
{
    public interface IOrcamentoRepository
    {
    Task<IEnumerable<Orcamento>> GetAll();
    Task<Orcamento?> GetById(int id);
    Task Add(Orcamento orcamento);
    Task Update(Orcamento orcamento);
    Task Delete(int id);
    }
}