using MinhaApi.Domain;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application;

public class UpdateProduct : IUpdateProduct
{
    private readonly IProdutoRepository _produtoRepository;

    public UpdateProduct(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Handler(int Id, Produto product) {
        await _produtoRepository.Update(Id, product);
    }
}
