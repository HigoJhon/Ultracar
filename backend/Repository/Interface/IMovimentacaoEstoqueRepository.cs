using backend.Models;

namespace backend.Repositories
{
    public interface IMovimentacaoEstoqueRepository
    {
        Task<IEnumerable<MovimentacaoEstoque>> GetAll();
        Task<MovimentacaoEstoque> GetById(int id);
        Task<MovimentacaoEstoque> Add(MovimentacaoEstoque movimentacao);
        Task<MovimentacaoEstoque> Update(MovimentacaoEstoque movimentacao);
        Task<bool> Delete(int id);
    }
}
