using backend.Models;

namespace backend.Repository
{
    public interface IPecaRepository
    {
        Task<Peca> GetPeca(int id);
        Task<List<Peca>> GetAll();
    }
}
