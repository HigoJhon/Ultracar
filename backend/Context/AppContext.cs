using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AppContext : DbContext, IAppContext
    {
        public DbSet<Peca> Pecas { get; set; } = null!;

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
    }

}