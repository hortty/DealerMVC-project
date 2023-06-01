using Microsoft.EntityFrameworkCore;
using TesteAPI.Models.Domain;

namespace TesteAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
