using backend.Models;

namespace backend.Repository
{
    public interface IClientesRepository
    {
        Task<List<Clientes>> GetAll();
        Task<Clientes> GetCliente(int id);
        Task<Clientes> Add(Clientes cliente);
        Task<Clientes> Update(Clientes cliente);
        Task<Clientes> Delete(int id);
    }
}