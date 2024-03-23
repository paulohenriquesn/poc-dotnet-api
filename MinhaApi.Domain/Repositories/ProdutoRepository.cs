using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> List();

    Task<Produto> getById(int Id);
    
    Task Save(Produto product);

    Task Delete(int Id);
}
