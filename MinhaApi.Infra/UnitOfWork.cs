using MinhaApi.Domain;
using MinhaApi.Infra.Databases;
using MinhaApi.Infra.Repositories;

namespace MinhaApi.Infra;

public class UnitOfWork : IUnitOfWork
{
    private IProdutoRepository? _ProdutoRepository;

    public AppDbContext _context;

    public IProdutoRepository ProdutoRepository {
        get {
            return _ProdutoRepository = _ProdutoRepository ?? new ProdutoPgRepository(_context);
        }
    }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose() {
        _context.Dispose();
    }
}
