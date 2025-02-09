using backend.Models;

namespace backend.Repository
{
    public interface IPecaRepository
    {
        Peca GetPeca(int id);
        List<Peca> GetAll();
    }
}
