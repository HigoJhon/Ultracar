using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Peca> Pecas { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Host=localhost;Port=5432;Database=oficina_db;Username=postgres;Password=Postgres123!";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}