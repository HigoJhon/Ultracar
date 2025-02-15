using backend.Models;

namespace backend.Repository
{
     public interface IOrcamentoPecaRepository
    {
        Task<List<OrcamentoPecas>> GetAll();
        Task<List<OrcamentoPecas>> GetByOrcamentoId(int orcamentoId);
        Task<OrcamentoPecas> GetById(int id);
        Task<OrcamentoPecas> Add(OrcamentoPecas orcamentoPeca);
        Task<OrcamentoPecas> Update(OrcamentoPecas orcamentoPeca);
        Task<bool> Delete(int id);
        Task<bool> UpdateEstado(int id, string estado);
    }
}