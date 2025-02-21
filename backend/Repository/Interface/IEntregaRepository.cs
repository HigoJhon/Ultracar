using backend.Models;

namespace backend.Repository
{
    public interface IEntregaRepository
    {
        Task<Entrega> AdicionarEntrega(Entrega entrega);
        Task<Entrega> ObterEntregaPorId(int id);
        Task<IEnumerable<Entrega>> ObterTodasEntregas();
    }
}