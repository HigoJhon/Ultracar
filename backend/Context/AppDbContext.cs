using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Orcamentos> Orcamentos { get; set; }
        public DbSet<OrcamentoPecas> OrcamentoPecas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Host=localhost;Port=5432;Database=oficina_db;Username=postgres;Password=Postgres123!";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orcamentos>()
                .HasMany(o => o.OrcamentoPecas)
                .WithOne(op => op.Orcamentos)
                .HasForeignKey(op => op.OrcamentoId);
        }
    }
}