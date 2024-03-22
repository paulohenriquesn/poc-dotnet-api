using MinhaApi.Domain;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infra.Repositories;

public class ProdutoPgRepository : ProdutoRepository
{
    public Task<IList<Produto>> ListAsync()
    {
        throw new NotImplementedException();
    }
}
