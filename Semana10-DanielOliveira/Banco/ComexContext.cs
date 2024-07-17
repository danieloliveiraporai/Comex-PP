using Comex_Modelos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Comex_Modelos.Banco;

public class ComexContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ComexDB;" +
        "Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
        "Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
