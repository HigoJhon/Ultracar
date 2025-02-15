using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<OrcamentoPecas> OrcamentoPecas { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

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
            modelBuilder.Entity<OrcamentoPecas>()
                .HasOne(op => op.Orcamento)
                .WithMany(o => o.Pecas) // <- Certifique-se de que há uma propriedade 'Pecas' em Orcamento
                .HasForeignKey(op => op.OrcamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrcamentoPecas>()
                .HasOne(op => op.Peca)
                .WithMany() // <- Se Peca não tem uma lista de OrcamentoPecas, mantenha WithMany()
                .HasForeignKey(op => op.PecaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}