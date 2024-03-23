using MinhaApi.Domain;

namespace MinhaApi.Application;

public class DeleteProduct : IDeleteProduct
{
    private IProdutoRepository _produtoRepository;

    public DeleteProduct(IProdutoRepository produtoRepository) {
        _produtoRepository = produtoRepository;
    }
    
    public async Task Handler(int id) {
        await _produtoRepository.Delete(id);
    }
}
