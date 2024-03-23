using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.Infra.Databases;

namespace MinhaApi.Infra.Repositories;

public class ProdutoPgRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    
    public ProdutoPgRepository(AppDbContext context) {
        _context = context;
    }
    public IEnumerable<Produto> List()
    {
        var products = _context.Produtos.ToList();
        return products;
    }

    public Produto getById(int Id)
    {
        var product = _context.Produtos.FirstOrDefault(p => p.ProdutoId == Id);
        return product;
    }
}
