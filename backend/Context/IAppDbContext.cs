using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public interface IAppDbContext
    {
        DbSet<Peca> Pecas { get; set; }
        DbSet<Clientes> Clientes { get; set; }
        DbSet<Orcamentos> Orcamentos { get; set; }
        DbSet<OrcamentoPecas> OrcamentoPecas { get; set; }

        public int SaveChanges();
    }
}