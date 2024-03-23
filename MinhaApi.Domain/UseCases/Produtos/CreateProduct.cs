using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface ICreateProduct
{
    Task Handler(Produto product);
}
