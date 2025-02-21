using backend.Models;

namespace backend.Repository
{
    public interface IPecaRepository
    {
        Task<List<Peca>> GetAll();
        Task<Peca> GetById(int id);
        Task<Peca> Add(Peca peca);
        Task<Peca> Update(int id, Peca peca);
        Task<Peca> Delete(int id);
        Task<bool> ExistInEstoque(int pecaId, int quantidade);
        Task updateEstoque(int pecaId, int quantidade);
    }
}