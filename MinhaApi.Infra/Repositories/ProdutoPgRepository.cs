using MinhaApi.Domain;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Infra.Repositories;

public class ProdutoPgRepository : IProdutoRepository
{
    public IList<Produto> List()
    {
        IList<Produto> list = new List<Produto>();
        Produto produto = new Produto
        {
            ProdutoId = 1,
            Nome = "Teste"
        };
        list.Add(produto);
        return list;
    }
}
