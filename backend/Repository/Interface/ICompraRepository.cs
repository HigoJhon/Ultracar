using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository
{
    public interface ICompraRepository
    {
        Task<List<Compras>> GetAll();
        Task<Compras> GetById(int id);
        Task<Compras> Add(Compras compraCompra);
        Task<Compras> Update(Compras compraCompra);
        Task<Compras> Delete(int id);
    }
}
