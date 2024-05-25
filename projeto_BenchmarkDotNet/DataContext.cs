using Microsoft.EntityFrameworkCore;

namespace projeto_BenchmarkDotNet
{
    public class DataContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estados> Estados { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost,1433;Database=teste-praticodb;User Id=sa;Password=Numsey#2021;TrustServerCertificate=True");
        }
    }
}
