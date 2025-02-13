using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public interface IAppDbContext
    {
        DbSet<Peca> Pecas { get; set; }
        DbSet<Orcamento> Orcamentos { get; set; }
        public int SaveChanges();
    }
}