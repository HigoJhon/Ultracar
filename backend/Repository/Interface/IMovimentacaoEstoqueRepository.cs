using backend.Models;

namespace backend.Repositories
{
    public interface IMovimentacaoEstoqueRepository
    {
        Task<IEnumerable<MovimentacaoEstoque>> GetAll();
        Task<MovimentacaoEstoque> GetById(int id);
        Task Add(MovimentacaoEstoque movimentacao);
        Task<bool> SalvarAsync();
    }
}
