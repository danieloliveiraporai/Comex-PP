using ComexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data;

public class ProdutoContext(DbContextOptions<ProdutoContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}
