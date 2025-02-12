using backend.Models;

namespace backend.Repository
{
    public interface IPecaRepository
    {
        Task<List<Peca>> GetAll();
        Task<Peca> Get(int id);
        Task<Peca> Create(Peca peca);
        Task<Peca> Update(Peca peca);
        Task<Peca> Delete(int id);
    }
}