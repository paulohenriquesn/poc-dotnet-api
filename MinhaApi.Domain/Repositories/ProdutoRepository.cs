using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface IProdutoRepository
{
    IList<Produto> List();
}
