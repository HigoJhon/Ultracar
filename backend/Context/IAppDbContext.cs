using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public interface IAppDbContext
    {
        DbSet<Peca> Pecas { get; set; }
        DbSet<Orcamento> Orcamentos { get; set; }
        DbSet<OrcamentoPecas> OrcamentoPecas { get; set; }
        DbSet<Compras> Compras { get; set; }
        DbSet<Entrega> Entregas { get; set; }
        DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }
        
        public int SaveChanges();
    }
}