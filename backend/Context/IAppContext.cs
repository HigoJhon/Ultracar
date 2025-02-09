using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context
{
    public interface IAppContext
    {
        DbSet<Peca> Pecas { get; set; }

        public int SaveChanges();
    }
}