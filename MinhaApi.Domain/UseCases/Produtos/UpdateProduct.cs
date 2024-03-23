using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface IUpdateProduct
{
    Task Handler(int Id, Produto product);
}
