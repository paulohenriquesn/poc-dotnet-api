using Microsoft.EntityFrameworkCore;
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
    public async Task<IEnumerable<Produto>> List()
    {
        var products = await _context.Produtos.AsNoTracking().ToListAsync();
        return products;
    }

    public async Task<Produto> getById(int Id)
    {
        var product = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == Id);
        return product;
    }

    public async Task Save(Produto product) {
        await _context.Produtos.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id) {
        _context.Produtos.Remove(new Produto(){ProdutoId = id});
       await _context.SaveChangesAsync();
    }

    public async Task Update(int Id, Produto product) {
        await _context.Produtos.Where(p => p.ProdutoId == Id).ExecuteUpdateAsync(setters => 
        setters
        .SetProperty(p => p.Nome, product.Nome)
        .SetProperty(p => p.ImagemUrl, product.ImagemUrl));
        await _context.SaveChangesAsync();
    }
}
