using Microsoft.EntityFrameworkCore;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infra.Databases;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    public DbSet<Produto> Produtos {get; set;}
    public DbSet<Categoria> Categorias {get; set;}
}
