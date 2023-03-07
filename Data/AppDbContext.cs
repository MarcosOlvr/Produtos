using Microsoft.EntityFrameworkCore;
using Produtos.Models;

namespace Produtos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
            .HasOne<Categoria>()
            .WithMany()
            .HasForeignKey(c => c.CategoriaFK)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}