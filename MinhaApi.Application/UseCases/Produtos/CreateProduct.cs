using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public class CreateProduct : ICreateProduct
{
    private IProdutoRepository _produtoRepository;
    public CreateProduct(IProdutoRepository produtoRepository) {
        _produtoRepository = produtoRepository;
    }

    public async Task Handler(Produto product) {
        await _produtoRepository.Save(product);
    }
}
