using MinhaApi.Domain.Entities;

namespace MinhaApi.MinhaApi.Domain.UseCases.Produtos;

public interface IRetrieveAll
{
    Task<IList<Produto>> Handler();
}
