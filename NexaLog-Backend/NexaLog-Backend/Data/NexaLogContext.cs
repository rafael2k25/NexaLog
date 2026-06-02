using Microsoft.EntityFrameworkCore;
using NexaLog_Backend.Models;

namespace NexaLog_Backend.Data
{
    public class NexaLogContext : DbContext
    {
        public NexaLogContext(DbContextOptions<NexaLogContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<ItemMovimentacao> ItensMovimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto);

            modelBuilder.Entity<Movimentacao>().ToTable("Movimentacao");
            modelBuilder.Entity<Movimentacao>().HasKey(m => m.IdMovimentacao);

            modelBuilder.Entity<Lote>().ToTable("Lote");
            modelBuilder.Entity<Lote>().HasKey(l => l.IdLote);

            modelBuilder.Entity<ItemMovimentacao>().ToTable("Item_Movimentacao");
            modelBuilder.Entity<ItemMovimentacao>()
                .HasKey(i => new
                {
                    i.FkProdutoIdProduto,
                    i.FkMovimentacaoIdMovimentacao
                });
        }
    }
}