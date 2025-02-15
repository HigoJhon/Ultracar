using backend.Models;

namespace backend.Services
{
    public interface IEntregaService
    {
        Task<Entrega> ObterEnderecoPorCep(string cep);
    }
}