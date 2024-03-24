using MinhaApi.Domain;

namespace MinhaApi.Application;

public class DeleteProduct : IDeleteProduct
{
    private IUnitOfWork _unitRepository;

    public DeleteProduct(IUnitOfWork unitRepository) {
        _unitRepository = unitRepository;
    }
    
    public async Task Handler(int id) {
        await _unitRepository.ProdutoRepository.Delete(id);
        await _unitRepository.Commit();
    }
}
