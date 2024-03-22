using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface ProdutoRepository
{
    Task<IList<Produto>> ListAsync();
}
