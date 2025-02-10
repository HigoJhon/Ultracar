using backend.Models;

namespace backend.Repository
{
    public interface IPecaRepository
    {
        Task<Peca> GetPeca(int id);
        Task<List<Peca>> GetAll();
        Task<Peca> Add(Peca peca);
        Task<Peca> Update(Peca peca);
        Task<Peca> Delete(int id);
    }
}
